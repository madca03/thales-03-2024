const getType = (o) => {
  return Object.prototype.toString.call(o);
}

export default {
  getType
}