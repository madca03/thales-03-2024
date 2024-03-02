import {Button, FormControl, Grid, InputLabel, MenuItem, Select} from "@mui/material";
import {DatePicker, LocalizationProvider} from "@mui/x-date-pickers";
import {AdapterMoment} from "@mui/x-date-pickers/AdapterMoment";
import React, {useState} from "react";

const WeatherDashboardFilter = (props) => {
  const handleChangeCountry = (event) => {
    if (props.onChangeCountry) {
      props.onChangeCountry(event.target.value);
    }
  };

  const handleChangeDate = (value) => {
    if (props.onChangeDate) {
      props.onChangeDate(value);
    }
  }

  const onClear = () => {
    if (props.onClear) props.onClear();
  }

  return (
    <Grid container className="weather-filter">
      <Grid item xs={3}>
        <FormControl fullWidth>
          <InputLabel id="country-label">Country</InputLabel>
          <Select
            labelId="country-label"
            id="weather-filter__country"
            value={props.country}
            label="Country"
            onChange={handleChangeCountry}
          >
            {props.countryOptions.map(x => <MenuItem key={x.value} value={x.value}>{x.text}</MenuItem>)}
          </Select>
        </FormControl>
      </Grid>
      <Grid item xs={3}>
        <FormControl>
          <LocalizationProvider dateAdapter={AdapterMoment}>
            <DatePicker label="Start date"
                        value={props.startDate}
                        onChange={handleChangeDate}/>
          </LocalizationProvider>
        </FormControl>
      </Grid>
      <Grid item xs={3}>
        <Button variant="contained" onClick={onClear}>Clear</Button>
      </Grid>
    </Grid>
  )
}

export default WeatherDashboardFilter;