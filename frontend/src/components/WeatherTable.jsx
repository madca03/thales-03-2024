import {Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow} from "@mui/material";
import React, {useEffect, useState} from "react";
import WeatherService from "../services/WeatherService";
import StringUtil from "../utils/StringUtil";
import DateUtil from "../utils/DateUtil";
import _ from "lodash";

const WeatherTable = (props) => {
  const [data, setData] = useState([]);
  const [dates, setDates] = useState([]);
  const [countryWeatherData, setCountryWeatherData] = useState([]);
  const [intervalOrder, setIntervalOrder] = useState([]);

  useEffect(() => {
    getCountryWeather();
  }, []);

  useEffect(() => {
    if (!Array.isArray(dates) || !dates.length) return;

    let countries = _.cloneDeep(countryWeatherData);

    // filter by the user's selected country
    if (!StringUtil.isNullOrEmpty(props.selectedCountry)) {
      countries = countries.filter(c => c.countryCode === props.selectedCountry);
    }

    // filter by the user's selected date
    if (props.selectedDate?.isValid() ?? false) {
      for (const country of countries) {
        country.dates = country.dates.filter(cd => {
          const timeDifferenceInDays = DateUtil.getTimeDifferenceInDays(DateUtil.parseDate(cd.date), props.selectedDate.toDate());
          const lessThan7Days = timeDifferenceInDays >= 0 && timeDifferenceInDays <= 7;
          return lessThan7Days;
        }).slice(0,7);
      }
    } else {
      for (const country of countries) {
        country.dates = country.dates.slice(0,1);
      }
    }

    setData(transformWeatherResponse(countries));
  }, [props.selectedCountry, props.selectedDate]);

  const getCountryWeather = () => {
    WeatherService.getCountryWeather(props.selectedCountry)
      .then((res) => {
        setIntervalOrder(res.intervalOrder);
        setDates(res.dates);
        setCountryWeatherData(res.countries);

        const initialCountriesData = _.cloneDeep(res.countries);
        for (const country of initialCountriesData) {
          country.dates = country.dates.slice(0,1);
        }

        setData(transformWeatherResponse(initialCountriesData));
      });
  }

  const transformWeatherResponse = (countries) => {
    const res = [];
    const datesFromCountry = countries[0].dates.map(x => x.date);

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

  return (
    <>
    {data.map((d) => (
      <div className="mb-5" key={d.date}>
        <div className="fw-bold mb-2">{d.date}</div>

        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Country</TableCell>
                {intervalOrder.map(x => (<TableCell key={x} align="center">{x}</TableCell>))}
              </TableRow>
            </TableHead>

            <TableBody>
              {d.countries.map((row) => (
                <TableRow
                  key={row.country}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>

                  <TableCell component="th" scope="row">
                    {row.country}
                  </TableCell>

                  {row.weather.map((weather) => (
                    <TableCell align="center" key={weather.interval}>
                      <img src={weather.icon}/><br/>
                      <span>{`${weather.tempC} \u00b0C / ${weather.tempF} \u00b0F`}</span>
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