app.filter('getValue', function ($filter) {
  return function (item, columnHeader) {
    var result = '';

    if (item) {
      var keys = columnHeader.Key.split(".");
      var object = "item";
      angular.forEach(keys, function (keysKey, keyIndex) {
        object += "['" + keysKey + "']";
      });
      result = eval(object);

      if (columnHeader.Type == 'Date') {
        result = $filter('ctime')(result);
      }
    }

    return result;
  };
});