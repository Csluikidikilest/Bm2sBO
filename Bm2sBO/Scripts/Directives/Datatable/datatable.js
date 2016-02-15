app.directive('datatable', function () {
  return {
    restrict: 'E',
    templateUrl: '/Scripts/Directives/Datatable/template.html',
    scope: {
      AlwaysShowFirstLastButtons: "=AlwaysShowFirstLastButtons",
      AvailablePagesSize: "=AvailablePagesSize",
      ColumnsHeader: "=ColumnsHeader",
      EntriesText: "=EntriesText",
      Interval: "=Interval",
      LargeStep: "=LargeStep",
      OfText: "=OfText",
      PageSize: "=PageSize",
      SearchText: "=SearchText",
      ShowText: "=ShowText",
      ShowingText: "=ShowingText",
      ShowPagination: "=ShowPagination",
      SmallStep: "=SmallStep",
      Source: "=Source",
      Title: "=Title",
      ToText: "=ToText"
    }
  };
}).controller('Datatable', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.generatePageList = function () {
    $scope.PagesList = [];
    for (i = 1; i <= $scope.PagesCount - 2; i++) {
      $scope.PagesList.push(i);
    };
  }

  $scope.jumpToPage = function (currentPage) {
    $scope.CurrentPage = currentPage;
    $scope.refreshPageSize();
  };

  $scope.refreshPageSize = function () {
    $scope.FirstItem = ($scope.CurrentPage * $scope.PageSize) + 1;
    $scope.LastItem = Math.min(($scope.CurrentPage + 1) * $scope.PageSize, $scope.ItemsCount);
  }

  $scope.ItemsCount = $scope.Source.length;
  $scope.PagesCount = Math.ceil($scope.ItemsCount / $scope.PageSize);
  $scope.jumpToPage(0);
  $scope.generatePageList();
}]);;