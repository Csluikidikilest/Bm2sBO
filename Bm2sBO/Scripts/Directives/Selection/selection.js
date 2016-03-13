app.directive('selection', function () {
  function link($scope, element, attrs) {
    $scope.Math = window.Math;

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

    $scope.inputMode = function () {
      if ($scope.selectionMode == 'multi') {
        return 'checkbox';
      }

      if ($scope.selectionMode == 'single') {
        return 'radio';
      }
    }

    $scope.toggleSelection = function (item) {
      if ($scope.selectionMode == 'multi') {
        var index = $scope.currentSelection.indexOf(item);
        if (index > -1) {
          $scope.currentSelection.splice(index, 1);
        } else {
          $scope.currentSelection.push(item);
        }
      }

      if ($scope.selectionMode == 'single') {
        $scope.currentSelection = [];
        $scope.currentSelection.push(item.Id);
      }
    }

    $scope.containsSelection = function (item) {
      if ($scope.currentSelection) {
        return ($scope.currentSelection.indexOf(item) > -1);
      } else {
        return false;
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
    templateUrl: '/Scripts/Directives/Selection/template.html',
    scope: {
      alwaysShowFirstLastButtons: '=',
      availablePagesSize: '=',
      columnsHeader: '=',
      currentPage: '=',
      currentSelection: '=',
      entriesText: '=',
      interval: '=',
      largeStep: '=',
      loading: '=',
      ofText: '=',
      pageSize: '=',
      searchText: '=',
      selectionMode: '=',
      showingText: '=',
      showText: '=',
      smallStep: '=',
      source: '=',
      toText: '=',
    },
    link: link,
  };
});
