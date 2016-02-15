app.controller('Translation', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;
  $scope.Languages = languages.Languages;

  $scope.AvailablePagesSize = [20, 50, 100, 200];
  $scope.PageSize = 20;
  $scope.Interval = 2;
  $scope.SmallStep = 1;
  $scope.LargeStep = 3;
  $scope.AlwaysShowFirstLastButtons = true;

  $scope.refreshPageSize = function () {
    $scope.FirstItem = ($scope.CurrentPage * $scope.PageSize) + 1;
    $scope.LastItem = Math.min(($scope.CurrentPage + 1) * $scope.PageSize, $scope.ItemsCount);
  }

  $scope.jumpToPage = function (currentPage) {
    $scope.CurrentPage = currentPage;
    $scope.refreshPageSize();
  };

  $scope.getValues = function () {
    var url = "/Translations/GetValues";
    var result;
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.Translations = data;
      $scope.ItemsCount = $scope.Translations.length;
      $scope.PagesCount = Math.ceil($scope.ItemsCount / $scope.PageSize);
      $scope.jumpToPage(0);
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
  $scope.PageSize = 20;
}]);