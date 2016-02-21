app.filter('find', function () {
  return function (datasource, filters) {
    var out = null;
    angular.forEach(datasource, function (item) {
      var find = true;
      angular.forEach(filters, function (filter) {
        if (item[filter.Key] !== filter.Value) {
          find = false;
        }
      });
      if (find) {
        out = item;
      }
    });

    return out;
  };
});