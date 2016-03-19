app.controller('Login', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {

  $scope.invalidLogin = true;

  $scope.formValid = function () {
    $scope.ValidLogin = $scope.UserLogin !== undefined && $scope.UserLogin != '';
    $scope.ValidPassword = $scope.Password !== undefined && $scope.Password != '';
    return $scope.ValidLogin && $scope.ValidPassword;
  }

  $scope.openSession = function () {
    var url = "/Login";
    var params = {
      UserLogin: $scope.UserLogin,
      Password: $scope.Password
    }

    $http.post(url, params).success(function (data, status) {
      window.location = "/";
    });
  }

  $scope.closeSession = function () {
    var url = "/Logout";
    var params = {
    }

    $http.post(url, params).success(function (data, status) {
      window.location = "/";
    });
  }
}]);