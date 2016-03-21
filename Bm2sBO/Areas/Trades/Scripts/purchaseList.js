app.controller('PurchaseList', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;

  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = purchaseListAvailablePagesSize;
  $scope.CanCreate = canCreate;
  $scope.CanDelete = canDelete;
  $scope.CanEdit = canEdit;
  $scope.ColumnsHeader = columnsHeaderPurchase;
  $scope.Configuration = configuration;
  $scope.CurrentPage = 0;
  $scope.EntriesText = entriesText;
  $scope.Interval = 2;
  $scope.LargeStep = 3;
  $scope.Loading = false;
  $scope.OfText = ofText;
  $scope.PageSize = purchaseListPageSize;
  $scope.SearchText = searchText;
  $scope.ShowingText = showingText;
  $scope.ShowText = showText;
  $scope.SmallStep = 1;
  $scope.Title = titlePurchase;
  $scope.ToText = toText;

  $scope.edit = function (line) {
    $scope.Edition = angular.copy(line);
    $('#modalEditionPurchase').modal('show');
  };

  $scope.add = function () {
    $scope.Edition = {};
    $('#modalEditionPurchase').modal('show');
  };

  $scope.formValid = function () {
    $scope.ValidCode = $scope.Edition !== undefined && $scope.Edition.Code !== undefined && $scope.Edition.Code != '';
    $scope.ValidName = $scope.Edition !== undefined && $scope.Edition.Name !== undefined && $scope.Edition.Name != '';
    $scope.ValidStartingDate = $scope.Edition !== undefined && $scope.Edition.StartingDate !== undefined && $scope.Edition.StartingDate != '';
    return $scope.ValidCode && $scope.ValidName && $scope.ValidStartingDate;
  };

  $scope.dismissValues = function () {
  };

  $scope.saveValues = function (line) {
    var url = "/Trades/Purchases/SetValue";
    var params = {
      purchase: line
    };

    $http.post(url, params).success(function (data, status) {
      $scope.getValues();
    });
  };

  $scope.deleteValue = function (line) {
    var url = "/Trades/Purchases/DeleteValue";
    var params = {
      purchase: line
    };

    $http.post(url, params).success(function (data, status) {
      if ($scope.DataSource.indexOf(line) > -1) {
        $scope.getValues();
      }
    });
  };

  $scope.getValues = function () {
    $scope.Loading = true;
    var url = "/Trades/Purchases/GetValues";
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