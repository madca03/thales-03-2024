import moment from "moment";

const parseDate = (dt) => {
  if (!dt) return '';
  return moment(dt).toDate();
}

const formatDate = (dt, format = 'YYYY-MM-DD') => {
  if (!dt || Object.prototype.toString.call(dt) !== '[object Date]') return '';
  return moment(dt).format(format);
}


const getTimeDifferenceInDays = (date1, date2) => {
  // Convert the dates to milliseconds since the Unix epoch
  const millisecondsPerDay = 24 * 60 * 60 * 1000; // Number of milliseconds in a day
  const time1 = date1.getTime();
  const time2 = date2.getTime();

  if (time1 < time2) return -1;

  // Calculate the absolute difference in milliseconds
  const differenceInMilliseconds = Math.abs(time1 - time2);

  // Calculate the difference in days
  const differenceInDays = Math.ceil(differenceInMilliseconds / millisecondsPerDay);

  // Check if the difference is less than or equal to 7 days
  return differenceInDays;
}

export default {
  parseDate,
  formatDate,
  getTimeDifferenceInDays
}