import {Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow} from "@mui/material";
import {useEffect, useState} from "react";
import WeatherService from "../services/WeatherService";
import StringUtil from "../utils/StringUtil";
import DateUtil from "../utils/DateUtil";
import _ from "lodash";

// selectedCountry / date
const WeatherTable = (props) => {
  const [data, setData] = useState([]);
  const [dates, setDates] = useState([]);
  const [intervalOrder, setIntervalOrder] = useState([]);
  const [countryWeatherData, setCountryWeatherData] = useState([]);

  useEffect(() => {
    WeatherService.getWeatherData()
      .then((res) => {
        setDates(res.dates);
        setIntervalOrder(res.intervalOrder);
        setCountryWeatherData(res.countries);

        // TODO: check if deep clone is needed.

        const initialCountriesData = _.cloneDeep(res.countries);

        for (const country of initialCountriesData) {
          country.dates = country.dates.slice(0,1);
        }

        setData(transformWeatherResponse(initialCountriesData));
      })
  }, []);

  // shallow copy / deep copy

  useEffect(() => {
    // check if there is country weather data
    if ((!Array.isArray(dates) || !dates.length) || (!countryWeatherData.length)) return;

    // shallow copy
    // TODO: check if deep clone is needed.
    let filteredCountries = _.cloneDeep(countryWeatherData);

    // check if props.selectedCountry is not null
    if (!StringUtil.isNullOrEmpty(props.selectedCountry)) {
      filteredCountries = filteredCountries.filter(c => c.countryCode === props.selectedCountry);
    }

    // check if there is props.selectedDate
    // props.selectedDate is of type moment
    if (props.selectedDate?.isValid() ?? false) {
      for (const country of filteredCountries) {
        country.dates = country.dates.filter(cd => {
          const timeDifferenceInDays = DateUtil.getTimeDifferenceInDays(DateUtil.parseDate(cd.date), props.selectedDate.toDate());
          return timeDifferenceInDays >= 0 && timeDifferenceInDays <= 7;
        }).slice(0,7);
      }
    } else {
      for (const country of filteredCountries) {
        country.dates = country.dates.slice(0,1);
      }
    }

    setData(transformWeatherResponse(filteredCountries));
  }, [props.selectedCountry, props.selectedDate]);

  const transformWeatherResponse = (countries) => {
    try {
      const res = [];
      const datesFromCountry = countries[0].dates.map(x => x.date);

      /*
        [
          {
            date: "2024-10-03",
            countries: [
              country: "",
              countryCode: "",
              weather: [
                {
                    "tempC": "26.7",
                    "tempF": "80",
                    "icon": "https://cdn.weatherapi.com/weather/64x64/night/176.png",
                    "interval": "00:00"
                },
              ]
            ]
          },
          {
            date: "2024-10-03",
            countries: [
              {
                country: "",
                countryCode: "",
                weather: [
                  {
                      "tempC": "26.7",
                      "tempF": "80",
                      "icon": "https://cdn.weatherapi.com/weather/64x64/night/176.png",
                      "interval": "00:00"
                  },
                ]
              }
            ]
          }
         ]
       */

      for (const dt of datesFromCountry) {
        const obj = {date: dt, countries: []};

        for (const c of countries) {
          const country = c.country;
          const countryCode = c.countryCode;
          const weather = c.dates.find(x => x.date === dt)?.weather;

          obj.countries.push({country, countryCode, weather});
        }

        res.push(obj);
      }

      return res;
    }
    catch (e) {
      debugger;
    }
  }

  return (
    <>
      {data.map(d => (
        <div key={d.date}>
          <div>{d.date}</div>

          <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell>Country</TableCell>
                  {intervalOrder.map(x => (
                    <TableCell align="right" key={x}>{x}</TableCell>
                  ))}
                </TableRow>
              </TableHead>
              <TableBody>
                {d.countries.map(c => (
                  <TableRow
                    key={c.countryCode}
                    sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                  >
                    <TableCell component="th" scope="row">
                      {c.country}
                    </TableCell>

                    {c.weather.map(w => (
                      <TableCell align="right"
                                 key={w.interval}>
                        <img src={w.icon}/>
                        <div>
                          {w.tempC} / {w.tempF}
                        </div>


                      </TableCell>
                    ))}

                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        </div>
      ))}
    </>
  )
}

export default WeatherTable;