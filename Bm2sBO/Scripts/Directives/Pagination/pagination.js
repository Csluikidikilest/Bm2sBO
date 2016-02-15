app.directive('pagination', function () {
  return {
    restrict: 'E',
    controller: '/Scripts/Directives/Pagination/controller.js',
    templateUrl: '/Scripts/Directives/Pagination/template.html',
    scope: {
      PageSize: "="
    }
  };
});