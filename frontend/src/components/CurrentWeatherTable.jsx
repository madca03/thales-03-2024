import {Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow} from "@mui/material";
import React, {useEffect, useState} from "react";
import WeatherService from "../services/WeatherService";

function createData(name, calories, fat, carbs, protein) {
  return { name, calories, fat, carbs, protein };
}

const rows = [
  createData('Frozen yoghurt', 159, 6.0, 24, 4.0),
  createData('Ice cream sandwich', 237, 9.0, 37, 4.3),
  createData('Eclair', 262, 16.0, 24, 6.0),
  createData('Cupcake', 305, 3.7, 67, 4.3),
  createData('Gingerbread', 356, 16.0, 49, 3.9),
];

const CurrentWeatherTable = (props) => {
  const [data, setData] = useState([]);
  const [intervalOrder, setIntervalOrder] = useState([]);

  useEffect(() => {
    getCountryWeather();
  }, []);

  useEffect(() => {
    getCountryWeather();
  }, [props.selectedCountry]);

  const getCountryWeather = () => {
    WeatherService.getCountryWeather(props.selectedCountry)
      .then((res) => {
        setIntervalOrder(res.intervalOrder);
        setData(res.countries);
      });
  }

  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Country</TableCell>
            {intervalOrder.map(x => (<TableCell align="center">{x}</TableCell>))}
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

              {row.weather.map((weather) => (
                <TableCell align="center">
                  <img src={weather.icon}/><br/>
                  <span>{`${weather.tempC} C / ${weather.tempF} F`}</span>
                </TableCell>
              ))}
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  )
}

export default CurrentWeatherTable;