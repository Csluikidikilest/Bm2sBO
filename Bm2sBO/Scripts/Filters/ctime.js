app.filter('ctime', function () {
  return function (jsonDate) {
    if (jsonDate) {
      return jsonDate.toLocaleDateString(configuration.defaultLocale, configuration.dateTimeOptions);
    }
    return jsonDate;
  };
});