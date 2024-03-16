import WeatherDashboardFilter from "../components/WeatherDashboardFilter";
import {useEffect, useState} from "react";
import WeatherService from "../services/WeatherService";
import WeatherTable from "../components/WeatherTable";

const WeatherDashboardPage = () => {
  const [countries, setCountries] = useState([]);
  const [country, setCountry] = useState('');
  const [selectedDate, setSelectedDate] = useState(null);

  // ------------------ START EVENT HANDLERS --------------------------------

  const onChangeCountry = (country) => {
    setCountry(country);
  }

  const onClearFilter = () => {
    setCountry('');
    setSelectedDate(null);
  }

  // ------------------ END EVENT HANDLERS --------------------------------

  // React component lifecycle
  // React hooks

  useEffect(() => {
    WeatherService.getCountries()
      .then((countries) => {
        setCountries(countries);
      });
    // side-effect will run once
    // or on component mount
  }, []);

  // 2 required props for controlled component
  // value
  // event handler to change the value

  return (
    <div>
      <WeatherDashboardFilter countryOptions={countries}
                              country={country}
                              onChangeCountry={onChangeCountry}
                              onClear={onClearFilter}
                              startDate={selectedDate}
                              onChangeDate={(date) => setSelectedDate(date)}/>

      <WeatherTable selectedCountry={country}
                    selectedDate={selectedDate}/>
    </div>
  )
}

export default WeatherDashboardPage;