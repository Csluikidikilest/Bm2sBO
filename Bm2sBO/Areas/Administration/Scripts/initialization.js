app.controller('Initialization', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Loading = false;
  $scope.NeedModulesInitialization = needModulesInitialization;

  $scope.ModulesInitialization = function () {
    $scope.Loading = true;
    var url = "/Administration/Initialization/ModulesInitialization";
    var params = {};

    $http.post(url, params).then(function () {
      $scope.NeedModulesInitialization = false;
      $scope.Loading = false;
    });
  };
}]);