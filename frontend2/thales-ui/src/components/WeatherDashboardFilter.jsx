import {Box, Button, FormControl, Grid, InputLabel, MenuItem, Select} from "@mui/material";
import {DatePicker, LocalizationProvider} from "@mui/x-date-pickers";
import {DemoContainer} from "@mui/x-date-pickers/internals/demo";
import {AdapterMoment} from "@mui/x-date-pickers/AdapterMoment";

const WeatherDashboardFilter = (props) => {

  // ------------------ START EVENT HANDLERS --------------------------------

  const handleChangeCountry = (event) => {
    if (props.onChangeCountry) {
      props.onChangeCountry(event.target.value);
    }
  };

  const handleChangeDate = (value) => {
    if (props.onChangeDate && typeof props.onChangeDate === 'function') {
      props.onChangeDate(value); // value is of type 'moment'
    }
  }

  const onClear = () => {
    // if parent component passed onClear props and onClear is a Function
    if (props.onClear && typeof props.onClear === 'function') {
      props.onClear();
    }
  }

  // ------------------ END EVENT HANDLERS --------------------------------

  return (
    <div>
      <Box sx={{ flexGrow: 1 }}>
        <Grid container spacing={2}>
          <Grid item xs={4}>
            <FormControl fullWidth>
              <InputLabel id="demo-simple-select-label">Country</InputLabel>
              <Select
                labelId="demo-simple-select-label"
                id="demo-simple-select"
                value={props.country ?? ''}
                label="Country"
                onChange={handleChangeCountry}
              >
                {props.countryOptions.map(o => (
                  <MenuItem value={o.value}
                            key={o.value}>
                    {o.text}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs={3}>
            <FormControl fullWidth>
              <LocalizationProvider dateAdapter={AdapterMoment}>
                <DemoContainer components={['DatePicker']}>
                  <DatePicker label="Basic date picker"
                              value={props.startDate}
                              onChange={handleChangeDate}/>
                </DemoContainer>
              </LocalizationProvider>
            </FormControl>
          </Grid>

          <Grid item>
            <Button variant="outlined" onClick={onClear}>Clear</Button>
          </Grid>
        </Grid>
      </Box>

    </div>
  )
}

export default WeatherDashboardFilter;