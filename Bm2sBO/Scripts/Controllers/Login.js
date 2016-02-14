app.controller('Login', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {

  $scope.invalidLogin = true;

  $scope.testForm = function () {
    $scope.invalidLogin = !$scope.UserLogin || $scope.UserLogin.length <= 0 || !$scope.Password || $scope.Password.length <= 0;
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