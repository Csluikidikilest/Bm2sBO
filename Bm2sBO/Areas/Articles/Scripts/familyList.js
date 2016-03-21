app.controller('FamilyList', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;

  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = familyListAvailablePagesSize;
  $scope.CanCreate = canCreate;
  $scope.CanDelete = canDelete;
  $scope.CanEdit = canEdit;
  $scope.ColumnsHeader = columnsHeaderFamily;
  $scope.Configuration = configuration;
  $scope.CurrentPage = 0;
  $scope.EntriesText = entriesText;
  $scope.Interval = 2;
  $scope.LargeStep = 3;
  $scope.Loading = false;
  $scope.OfText = ofText;
  $scope.OrderColumn = $scope.ColumnsHeader[0].Key;
  $scope.OrderReverse = false;
  $scope.PageSize = familyListPageSize;
  $scope.SearchText = searchText;
  $scope.ShowingText = showingText;
  $scope.ShowText = showText;
  $scope.SmallStep = 1;
  $scope.Title = titleFamily;
  $scope.ToText = toText;

  $scope.edit = function (line) {
    $scope.Edition = angular.copy(line);
    $('#modalEditionFamily').modal('show');
  };

  $scope.add = function () {
    $scope.Edition = {};
    $('#modalEditionFamily').modal('show');
  };

  $scope.formValid = function () {
    $scope.ValidCode = $scope.Edition !== undefined && $scope.Edition.Code !== undefined && $scope.Edition.Code != '';
    $scope.ValidDesignation = $scope.Edition !== undefined && $scope.Edition.Designation !== undefined && $scope.Edition.Designation != '';
    $scope.ValidStartingDate = $scope.Edition !== undefined && $scope.Edition.StartingDate !== undefined && $scope.Edition.StartingDate != '';
    return $scope.ValidCode && $scope.ValidDesignation && $scope.ValidStartingDate;
  };

  $scope.dismissValues = function () {
  };

  $scope.saveValues = function (line) {
    var url = "/Articles/Families/SetValue";
    var params = {
      articleFamily: line
    };

    $http.post(url, params).success(function (data, status) {
      $scope.getValues();
    });
  };

  $scope.deleteValue = function (line) {
    var url = "/Articles/Families/DeleteValue";
    var params = {
      articleFamily: line
    };

    $http.post(url, params).success(function (data, status) {
      if ($scope.DataSource.indexOf(line) > -1) {
        $scope.getValues();
      }
    });
  };

  $scope.getValues = function () {
    $scope.Loading = true;
    var url = "/Articles/Families/GetValues";
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.DataSource = data;
      $scope.ItemsCount = $scope.DataSource.length;
    }).then(function () {
      $scope.Loading = false;
    });
  };

  $scope.getValues();
}]);