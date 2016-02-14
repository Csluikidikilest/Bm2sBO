app.controller('Translation', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;
  $scope.Languages = languages.Languages;

  $scope.PageSize = 20;
  $scope.Interval = 2;
  $scope.SmallStep = 1;
  $scope.LargeStep = 3;
  $scope.AlwaysShowFirstLastButtons = true;

  $scope.jumpToPage = function (currentPage) {
    $scope.CurrentPage = currentPage;
    $scope.FirstItem = ($scope.CurrentPage * $scope.PageSize) + 1;
    $scope.LastItem = ($scope.CurrentPage + 1) * $scope.PageSize;
  };

  $scope.getValues = function () {
    var url = "/Translations/GetValues";
    var result;
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.CurrentPage = 0;
      $scope.Translations = data;
      $scope.ItemsCount = $scope.Translations.length;
      $scope.PagesCount = Math.ceil($scope.ItemsCount / $scope.PageSize);
      $scope.PagesList = [];
      for (i = 1; i <= $scope.PagesCount - 2; i++) {
        $scope.PagesList.push(i);
      };
    });
  };

  $scope.setValue = function (screen, key, languageId, value) {
    var url = "/Translations/SetValue";
    var result = defaultValue;
    var params = {
      screen: screen,
      key: key,
      languageId: languageId,
      value: value
    };

    $http.post(url, params).success(function (data, status) {
      result = data;
    });

    return result;
  };

  $scope.getValues();
}]);