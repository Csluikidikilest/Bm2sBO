app.directive('pagination', function () {
  function link($scope, element, attrs) {
    $scope.Math = window.Math;
    $scope.PagesList = [];

    $scope.jumpToPage = function (newPage) {
      $scope.currentPage = newPage;
    }

    $scope.refreshPageCount = function () {
      $scope.PagesCount = Math.ceil($scope.itemsCount / $scope.pageSize);
      $scope.PagesList = [];
      for (i = 1; i <= $scope.PagesCount - 2; i++) {
        $scope.PagesList.push(i);
      };
      $scope.jumpToPage(0);
    }

    $scope.$watch('itemsCount', function (newValue, oldValue) {
      if (newValue != oldValue) {
        $scope.refreshPageCount();
      }
    }, true);

    $scope.$watch('pageSize', function (newValue, oldValue) {
      if (newValue != oldValue) {
        $scope.refreshPageCount();
      }
    }, true);
  }

  return {
    restrict: 'AE',
    replace: 'true',
    templateUrl: '/Scripts/Directives/Pagination/template.html',
    scope: {
      alwaysShowFirstLastButtons: '=',
      currentPage: '=',
      interval: '=',
      itemsCount: '=',
      largeStep: '=',
      pageSize: '=',
      smallStep: '=',
    },
    link: link,
  };
});