app.directive('pagination', function () {
  return {
    restrict: 'AE',
    replace: 'true',
    templateUrl: '/Scripts/Directives/Pagination/template.html',
    scope: 'true'
  };
});