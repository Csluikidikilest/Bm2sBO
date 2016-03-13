﻿app.directive('datatable', function () {
  function link($scope, element, attrs) {
    $scope.Math = window.Math;

    $scope.add = function () {
      $scope.onAddItem();
    }

    $scope.delete = function (item) {
      $scope.currentLine = item;
      $scope.onDeleteItem();
    }

    $scope.edit = function (item) {
      $scope.currentLine = item;
      $scope.onEditItem();
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
      currentLine: '=',
      currentPage: '=',
      entriesText: '=',
      interval: '=',
      largeStep: '=',
      loading: '=',
      ofText: '=',
      onAddItem: '&',
      onDeleteItem: '&',
      onEditItem: '&',
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
