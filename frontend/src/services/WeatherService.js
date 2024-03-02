import axios from "axios";
import APIEndpoints from "../constants/APIEndpoints";

const getCountries = () => {
  return axios.get(APIEndpoints.GetCountries).then((res) => res.data);
}

const getCountryWeather = (countryCode) => {
  const axiosOptions = {
    url: APIEndpoints.GetCountryWeather,
    method: "GET"
  }

  if (countryCode) axiosOptions.params = {countryCode};

  return axios(axiosOptions).then((res) => res.data);
}

const getWeatherForecast = (countryCode, startDate) => {
  let axiosOptions = {
    url: APIEndpoints.GetWeatherForecast,
    method: "GET",
    params: {}
  }

  if (countryCode) axiosOptions.params.countryCode = countryCode;
  if (startDate) axiosOptions.params.startDate = startDate;

  return axios(axiosOptions).then((res) => res.data);
}

export default {
  getCountries,
  getCountryWeather,
  getWeatherForecast
}