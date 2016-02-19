app.directive('inputFormat', function () {
  return {
    require: 'ngModel',
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
