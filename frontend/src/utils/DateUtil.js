import moment from "moment";

const parseDate = (dt) => {
  if (!dt) return '';
  return moment(dt).toDate();
}

const formatDate = (dt, format = 'YYYY-MM-DD') => {
  if (!dt || Object.prototype.toString.call(dt) !== '[object Date]') return '';
  return moment.format(dt, format);
}

export default {
  parseDate,
  formatDate
}