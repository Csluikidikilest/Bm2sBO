app.directive('datatable', function () {
  function link($scope, element, attrs) {
    $scope.Math = window.Math;

    $scope.add = function () {
      $scope.onAddItem();
    }

    $scope.delete = function (line) {
      $scope.onDeleteItem({ line: line });
    }

    $scope.edit = function (line) {
      $scope.onEditItem({ line: line });
    }

    $scope.refresh = function () {
      $scope.onRefresh();
    }

    $scope.$watch('CurrentPage', function (newValue, oldValue) {
      if (newValue != oldValue) {
        $scope.refreshPageSize();
      }
    }, true);

    $scope.$watch('pageSize', function (newValue, oldValue) {
      if (newValue != oldValue) {
        $scope.jumpToPage(0);
      }
    }, true);

    $scope.$watch('SearchFilter', function (newValue, oldValue) {
      if (newValue != oldValue) {
        $scope.refreshPageSize();
      }
    }, true);

    $scope.$watch('source', function (newValue, oldValue) {
      if (newValue) {
        $scope.ItemsCount = $scope.source.length;
        $scope.jumpToPage(0);
      }
    }, true);

    $scope.changeOrder = function (column) {
      if ($scope.orderColumn == column) {
        $scope.orderReverse = !$scope.orderReverse;
      } else {
        $scope.orderColumn = column;
        $scope.orderReverse = false;
      }
    }

    $scope.jumpToPage = function (currentPage) {
      $scope.CurrentPage = currentPage;
      $scope.refreshPageSize();
    };

    $scope.refreshPageSize = function () {
      $scope.FirstItem = ($scope.CurrentPage * $scope.pageSize) + 1;
      $scope.LastItem = Math.min(($scope.CurrentPage + 1) * $scope.pageSize, $scope.filteredSource.length);
    };
  }

  return {
    restrict: 'AE',
    replace: 'true',
    templateUrl: '/Scripts/Directives/Datatable/template.html',
    scope: {
      alwaysShowFirstLastButtons: '=',
      availablePagesSize: '=',
      canCreate: '=',
      canDelete: '=',
      canEdit: '=',
      columnsHeader: '=',
      currentPage: '=',
      entriesText: '=',
      interval: '=',
      largeStep: '=',
      loading: '=',
      ofText: '=',
      onAddItem: '&',
      onDeleteItem: '&',
      onEditItem: '&',
      onRefresh: '&',
      orderColumn: '=',
      orderReverse: '=',
      pageSize: '=',
      searchText: '=',
      showingText: '=',
      showText: '=',
      smallStep: '=',
      source: '=',
      title: '=',
      toText: '=',
    },
    link: link,
  };
});
