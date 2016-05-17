var DateEqual = function (actual, expected) {
  return new Date(actual) === new Date(expected);
}

var DateGreaterThan = function (actual, expected) {
  return new Date(actual) > new Date(expected);
}

var DateGreaterThanOrEqual = function (actual, expected) {
  return DateGreaterThan(actual, expected) || DateEqual(actual, expected);
}

var DateLowerThan = function (actual, expected) {
  return new Date(actual) < new Date(expected);
}

var DateLowerThanOrEqual = function (actual, expected) {
  return DateLowerThan(actual, expected) || DateEqual(actual, expected);
}
