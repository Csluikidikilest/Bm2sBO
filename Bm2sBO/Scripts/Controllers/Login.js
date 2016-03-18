app.controller('Login', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {

  $scope.invalidLogin = true;

  $scope.formValid = function () {
    return $scope.UserLogin !== undefined && $scope.UserLogin.length != '' && $scope.Password !== undefined && $scope.Password != '';
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