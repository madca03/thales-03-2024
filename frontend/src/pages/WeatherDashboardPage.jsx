import './App.scss';
import './WeatherDashboardPage.scss';
import {
  Container,
} from "@mui/material";
import React, {useEffect, useState} from "react";
import WeatherDashboardFilter from "../components/WeatherDashboardFilter";
import WeatherService from "../services/WeatherService";
import WeatherTable from "../components/WeatherTable";

const WeatherDashboardPage = () => {
  const [country, setCountry] = useState('');
  const [selectedDate, setSelectedDate] = useState(null);
  const [countryOptions, setCountryOptions] = useState([]);

  useEffect(() => {
    WeatherService.getCountries()
      .then((res) => {
        setCountryOptions(res);
      })
  }, []);

  const onClearFilter = () => {
    setCountry('');
    setSelectedDate(null);
  }

  return (
    <Container className="weather-dashboard-page">
      <WeatherDashboardFilter onClear={onClearFilter}
                              country={country}
                              countryOptions={countryOptions}
                              startDate={selectedDate}
                              onChangeCountry={(countryCode) => setCountry(countryCode)}
                              onChangeDate={(date) => setSelectedDate(date)}/>

      <WeatherTable selectedCountry={country} selectedDate={selectedDate}/>
    </Container>
  )
}

export default WeatherDashboardPage;