import axios from "axios";

const getCountries = () => {
  return axios.get("api/weather/countries").then(res => res.data);
}

const getWeatherData = () => {
  return axios.get("api/weather").then(res => res.data);
}

export default {
  getCountries,
  getWeatherData
}