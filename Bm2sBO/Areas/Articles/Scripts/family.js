app.controller('Family', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;
  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = [20, 50, 100, 200];
  $scope.ColumnsHeader = columnsHeaderFamily;
  $scope.LargeStep = 3;
  $scope.PageSize = 20;
  $scope.Interval = 2;
  $scope.SmallStep = 1;
  $scope.Configuration = configuration;

  $scope.CanCreate = canCreate;
  $scope.CanDelete = canDelete;
  $scope.CanEdit = canEdit;

  $scope.EntriesText = entriesText;
  $scope.OfText = ofText;
  $scope.SearchText = searchText;
  $scope.ShowingText = showingText;
  $scope.ShowText = showText;
  $scope.Title = titleFamily;
  $scope.ToText = toText;

  $scope.edit = function (line) {
    $scope.Edition = angular.copy(line);
    $('#modalEditionFamily').modal('show');
  };

  $scope.dismissValues = function () {
  };

  $scope.saveValues = function (line) {
    var url = "/Articles/Families/SetValue";
    var params = {
      articleFamily: line
    };

    $http.post(url, params).success(function (data, status) {
      result = data;

      var currentLine = $filter('find')($scope.DataSource, [{ Key: 'Id', Value: data.Id }]);
      currentLine.Code = data.Code;
      currentLine.Designation = data.Designation;
      currentLine.Description = data.Description;
      currentLine.StartingDate = data.StartingDate;
      currentLine.AccountingEntry = data.AccountingEntry;
    });
  };

  $scope.deleteValue = function (item) {
    var url = "/Articles/Families/DeleteValue";
    var params = {
      articleFamily: item
    };

    $http.post(url, params).success(function (data, status) {
      result = data;
    });
  };

  $scope.getValues = function () {
    var url = "/Articles/Families/GetValues";
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

  $scope.getValues();
}]);