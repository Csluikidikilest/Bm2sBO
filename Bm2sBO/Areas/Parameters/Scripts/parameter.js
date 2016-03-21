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
  $scope.OrderColumn = "Code";
  $scope.OrderReverse = false;
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
    $scope.ValidDescription = $scope.Edition !== undefined && $scope.Edition.Description !== undefined && $scope.Edition.Description != '';
    $scope.ValidValueType = $scope.Edition !== undefined && $scope.Edition.ValueType !== undefined && $scope.Edition.ValueType != '';
    $scope.ValidValue = $scope.Edition !== undefined && ($scope.Edition.ValueType != 's' || ($scope.Edition.sValue !== undefined && $scope.Edition.sValue != '')) && ($scope.Edition.ValueType != 'i' || ($scope.Edition.iValue !== undefined && $scope.Edition.iValue != '')) && ($scope.Edition.ValueType != 'f' || ($scope.Edition.fValue !== undefined && $scope.Edition.fValue != '')) && ($scope.Edition.ValueType != 'b' || ($scope.Edition.bValue !== undefined && $scope.Edition.bValue != '')) && ($scope.Edition.ValueType != 'd' || ($scope.Edition.dValue !== undefined && $scope.Edition.dValue != ''));
    return $scope.ValidCode && $scope.ValidDescription && $scope.ValidValueType && $scope.ValidValue;
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

  $scope.changeOrder = function (column) {
    if ($scope.OrderColumn == column) {
      $scope.OrderReverse = !$scope.OrderReverse;
    } else {
      $scope.OrderColumn = column;
      $scope.OrderReverse = false;
    }
  }

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