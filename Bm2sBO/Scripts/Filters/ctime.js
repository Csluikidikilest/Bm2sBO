app.filter('ctime', function () {
  return function (jsonDate) {
    return jsonDate.toLocaleDateString(configuration.defaultLocale, configuration.dateTimeOptions);
  };
});