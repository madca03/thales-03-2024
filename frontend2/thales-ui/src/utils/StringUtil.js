const isNullOrEmpty = (v) => {
  return typeof v !== 'string' || !v.length;
}

export default {
  isNullOrEmpty
}