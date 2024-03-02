import './App.scss';
import './WeatherDashboardPage.scss';
import {
  Container,
} from "@mui/material";
import React, {useEffect, useState} from "react";
import WeatherDashboardFilter from "../components/WeatherDashboardFilter";
import WeatherService from "../services/WeatherService";
import CurrentWeatherTable from "../components/CurrentWeatherTable";
import WeatherForecastTable from "../components/WeatherForecastTable";

const WeatherDashboardPage = () => {
  const [country, setCountry] = useState('');
  const [startDate, setStartDate] = useState(null);
  const [countryOptions, setCountryOptions] = useState([]);

  useEffect(() => {
    WeatherService.getCountries()
      .then((res) => {
        setCountryOptions(res);
      })
  }, []);

  const onClearFilter = () => {
    setCountry('');
    setStartDate(null);
  }

  return (
    <Container className="weather-dashboard-page">
      <WeatherDashboardFilter onClear={onClearFilter}
                              country={country}
                              countryOptions={countryOptions}
                              startDate={startDate}
                              onChangeCountry={(countryCode) => setCountry(countryCode)}
                              onChangeDate={(date) => setStartDate(date)}/>

      {!startDate && <CurrentWeatherTable selectedCountry={country}/>}
      {startDate && <WeatherForecastTable selectedCountry={country} startDate={startDate}/>}
    </Container>
  )
}

export default WeatherDashboardPage;