app.controller('Article', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;
  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = [20, 50, 100, 200];
  $scope.ColumnsHeader = columnsHeader;
  $scope.LargeStep = 3;
  $scope.PageSize = 20;
  $scope.Interval = 2;
  $scope.SmallStep = 1;

  $scope.CanCreate = canCreate;
  $scope.CanDelete = canDelete;
  $scope.CanEdit = canEdit;

  $scope.EntriesText = entriesText;
  $scope.OfText = ofText;
  $scope.SearchText = searchText;
  $scope.ShowingText = showingText;
  $scope.ShowText = showText;
  $scope.Title = title;
  $scope.ToText = toText;

  $scope.edit = function (line) {
    $scope.Edition = line;
    $('#modalEdition').modal('show');
  };

  $scope.getValues = function () {
    var url = "/Articles/Articles/GetValues";
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.DataSource = data;
      $scope.ItemsCount = $scope.DataSource.length;
      $scope.jumpToPage(0);
    });
  };

  $scope.jumpToPage = function (currentPage) {
    $scope.CurrentPage = currentPage;
    $scope.refreshPageSize();
  };

  $scope.refreshPageSize = function () {
    $scope.FirstItem = ($scope.CurrentPage * $scope.PageSize) + 1;
    $scope.LastItem = Math.min(($scope.CurrentPage + 1) * $scope.PageSize, $scope.ItemsCount);
    $scope.PagesCount = Math.ceil($scope.ItemsCount / $scope.PageSize);
    $scope.PagesList = [];
    for (i = 1; i <= $scope.PagesCount - 2; i++) {
      $scope.PagesList.push(i);
    };
  };

  $scope.setValue = function (item) {
    var url = "/Articles/SetValue";
    var params = {
      article: item
    };

    $http.post(url, params).success(function (data, status) {
      result = data;
    });
  };

  $scope.deleteValue = function (item) {
    var url = "/Articles/DeleteValue";
    var params = {
      article: item
    };

    $http.post(url, params).success(function (data, status) {
      result = data;
    });
  };

  $scope.getValues();
}]);