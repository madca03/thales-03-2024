import {Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow} from "@mui/material";
import React, {useEffect, useState} from "react";
import WeatherService from "../services/WeatherService";
import ObjectUtil from "../utils/ObjectUtil";

const WeatherForecastTable = (props) => {
  const [data, setData] = useState([]);
  const [dates, setDates] = useState([]);

  useEffect(() => {
    getWeatherForecast();
  }, []);

  useEffect(() => {
    getWeatherForecast();
  }, [props.selectedCountry, props.startDate]);

  const getWeatherForecast = () => {
    let startDate;

    if (ObjectUtil.getType(props.startDate) === '[object String]') startDate = props.startDate;
    if (ObjectUtil.get)

    WeatherService.getWeatherForecast(props.selectedCountry, props.startDate)
      .then((res) => {
        setDates(res.dates);
        setData(res.countries);
      });
  }


  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Country</TableCell>
            {dates.map(x => (<TableCell align="center">{x}</TableCell>))}
          </TableRow>
        </TableHead>
        <TableBody>
          {data.map((row) => (
            <TableRow
              key={row.country}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.country}
              </TableCell>

              {row.forecast.map((forecast) => (
                <TableCell align="center">{`${forecast.tempC} C / ${forecast.tempF} F`}</TableCell>
              ))}
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  )
}

export default  WeatherForecastTable;