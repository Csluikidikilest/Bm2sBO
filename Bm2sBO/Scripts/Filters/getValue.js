app.filter('getValue', function ($filter, $sce) {
  return function (item, columnHeader) {
    var result = '';

    if (item) {
      var keys = columnHeader.Key.split(".");
      var object = "item";
      angular.forEach(keys, function (keysKey, keyIndex) {
        object += "['" + keysKey + "']";
      });
      result = eval(object);

      if (columnHeader.Type == 'CheckBox') {
        if (result) {
          result = '<i class="fa fa-check-square-o"></i>';
        } else {
          result = '<i class="fa fa-square-o"></i>';
        }

        result = $sce.trustAsHtml(result);
      }

      if (columnHeader.Type == 'Date') {
        result = $filter('ctime')(result);
      }
    }

    return result;
  };
});