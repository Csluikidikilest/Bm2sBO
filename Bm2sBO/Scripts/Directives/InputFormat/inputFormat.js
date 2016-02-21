app.directive('inputDateFormat', function () {
  return {
    require: 'ngModel',
    restrict: 'A',
    link: function (scope, element, attrs, ngModelController) {
      ngModelController.$parsers.push(function (data) {
        console.log(scope);
        console.log(element);
        console.log(attrs);
        console.log(ngModelController);
        return data;
      });

      ngModelController.$formatters.push(function (data) {
        console.log(scope);
        console.log(element);
        console.log(attrs);
        console.log(ngModelController);
        return data;
      });
    }
  };
});
