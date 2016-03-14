app.controller('FamilyList', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;

  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = [20, 50, 100, 200];
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
  $scope.PageSize = 20;
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

  $scope.deleteValue = function (line) {
    var url = "/Articles/Families/DeleteValue";
    var params = {
      articleFamily: line
    };

    $http.post(url, params).success(function (data, status) {
      var index = $scope.DataSource.indexOf(line);
      if (index > -1) {
        $scope.DataSource.splice(index, 1);
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