app.controller('Article', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Articles = articles.Articles;
}]);