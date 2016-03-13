app.controller('SubFamilyList', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;

  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = [20, 50, 100, 200];
  $scope.CanCreate = canCreate;
  $scope.CanDelete = canDelete;
  $scope.CanEdit = canEdit;
  $scope.ColumnsHeader = columnsHeaderSubFamily;
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
  $scope.Title = titleSubFamily;
  $scope.ToText = toText;

  $scope.SelectListFamilies = selectListFamilies;

  $scope.$watch('CurrentLine', function (newValue, oldValue) {
    if (newValue != oldValue) {
      $scope.Edition = angular.copy($scope.CurrentLine);
    }
  }, true);

  $scope.edit = function () {
    $('#modalEditionSubFamily').modal('show');
  };

  $scope.dismissValues = function () {
  };

  $scope.saveValues = function (line) {
    var url = "/Articles/SubFamilies/SetValue";
    var params = {
      articleSubFamily: line
    };

    $http.post(url, params).success(function (data, status) {
      result = data;

      var currentLine = $filter('find')($scope.DataSource, [{ Key: 'Id', Value: data.Id }]);
      currentLine.Code = data.Code;
      currentLine.Designation = data.Designation;
      currentLine.Description = data.Description;
      currentLine.StartingDate = data.StartingDate;
      currentLine.ArticleFamily = data.ArticleFamily;
      currentLine.AccountingEntry = data.AccountingEntry;
    });
  };

  $scope.deleteValue = function (item) {
    var url = "/Articles/SubFamilies/DeleteValue";
    var params = {
      articleSubFamily: item
    };

    $http.post(url, params).success(function (data, status) {
      result = data;
    });
  };

  $scope.getValues = function () {
    $scope.Loading = true;
    var url = "/Articles/SubFamilies/GetValues";
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