app.controller('ParameterList', ['$scope', '$http', '$filter', function ($scope, $http, $filter) {
  $scope.Math = window.Math;

  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = parameterListAvailablePagesSize;
  $scope.CanCreate = canCreate;
  $scope.CanDelete = canDelete;
  $scope.CanEdit = canEdit;
  $scope.ColumnHeaderdValue = columnHeaderdValue;
  $scope.Configuration = configuration;
  $scope.CurrentPage = 0;
  $scope.EntriesText = entriesText;
  $scope.Interval = 2;
  $scope.LargeStep = 3;
  $scope.Loading = false;
  $scope.OfText = ofText;
  $scope.PageSize = parameterListPageSize;
  $scope.SearchText = searchText;
  $scope.ShowingText = showingText;
  $scope.ShowText = showText;
  $scope.SmallStep = 1;
  $scope.Title = titleParameter;
  $scope.ToText = toText;

  $scope.$watch('PageSize', function (newValue, oldValue) {
    if (newValue != oldValue) {
      $scope.jumpToPage(0);
    }
  }, true);

  $scope.$watch('SearchFilter', function (newValue, oldValue) {
    if (newValue != oldValue) {
      $scope.refreshPageSize();
    }
  }, true);

  $scope.edit = function (line) {
    $scope.Edition = angular.copy(line);
    $('#modalEditionParameter').modal('show');
  };

  $scope.formValid = function () {
    $scope.ValidCode = $scope.Edition !== undefined && $scope.Edition.Code !== undefined && $scope.Edition.Code != '';
    $scope.ValidName = $scope.Edition !== undefined && $scope.Edition.Name !== undefined && $scope.Edition.Name != '';
    $scope.ValidStartingDate = $scope.Edition !== undefined && $scope.Edition.StartingDate !== undefined && $scope.Edition.StartingDate != '';
    return true; //$scope.ValidCode && $scope.ValidName && $scope.ValidStartingDate;
  };

  $scope.dismissValues = function () {
  };

  $scope.saveValues = function (line) {
    var url = "/Parameters/Parameters/SetValue";
    var params = {
      brand: line
    };

    $http.post(url, params).success(function (data, status) {
      $scope.getValues();
    });
  };

  $scope.deleteValue = function (line) {
    var url = "/Parameters/Parameters/DeleteValue";
    var params = {
      brand: line
    };

    $http.post(url, params).success(function (data, status) {
      if ($scope.DataSource.indexOf(line) > -1) {
        $scope.getValues();
      }
    });
  };

  $scope.jumpToPage = function (currentPage) {
    $scope.CurrentPage = currentPage;
    $scope.refreshPageSize();
  };

  $scope.refreshPageSize = function () {
    $scope.FirstItem = ($scope.CurrentPage * $scope.PageSize) + 1;
    $scope.LastItem = Math.min(($scope.CurrentPage + 1) * $scope.PageSize, $scope.FilteredSource.length);
  };

  $scope.getValues = function () {
    $scope.Loading = true;
    var url = "/Parameters/Parameters/GetValues";
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.DataSource = data;
      $scope.FilteredSource = data;
      $scope.ItemsCount = $scope.DataSource.length;
      $scope.jumpToPage(0);
    }).then(function () {
      $scope.Loading = false;
    });
  };

  $scope.getValues();
}]);