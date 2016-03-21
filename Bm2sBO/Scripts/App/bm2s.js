var app = angular.module('bm2s', ['ngStorage', 'ngSanitize']);

var regexIso8601 = /Date\((\d{13})[\+\-](\d{4})\)/;

function convertDateStringsToDates(input) {
  // Ignore things that aren't objects.
  if (typeof input !== "object") return input;

  for (var key in input) {
    if (!input.hasOwnProperty(key)) continue;

    var value = input[key];
    var match;
    // Check for string properties which look like dates.
    if (typeof value === "string" && (match = value.match(regexIso8601))) {
      var milliseconds = parseInt(match[1]);
      if (!isNaN(milliseconds)) {
        input[key] = new Date(milliseconds);
      }
    } else if (typeof value === "object") {
      // Recurse into object
      convertDateStringsToDates(value);
    }
  }
};

app.config(["$httpProvider", function ($httpProvider) {
  $httpProvider.defaults.transformResponse.push(function (responseData) {
    convertDateStringsToDates(responseData);
    return responseData;
  });
}]);
