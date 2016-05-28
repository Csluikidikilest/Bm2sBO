app.controller('Setup', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Loading = false;

  $scope.ConfirmSetup = function () {
    $scope.Loading = true;
    var url = "/Administration/Administration/ModulesInitialization";
    var params = {};

    $http.post(url, params).then(function () {
      $scope.NeedModulesInitialization = false;
      $scope.Loading = false;
    });
  };
}]);