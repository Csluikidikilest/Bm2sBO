app.controller('SubFamily', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;
  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = [20, 50, 100, 200];
  $scope.ColumnsHeader = columnsHeaderSubFamily;
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
  $scope.Title = titleSubFamily;
  $scope.ToText = toText;

}]);