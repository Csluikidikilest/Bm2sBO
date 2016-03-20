﻿app.controller('ArticleList', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;

  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = articleListAvailablePagesSize;
  $scope.CanCreate = canCreate;
  $scope.CanDelete = canDelete;
  $scope.CanEdit = canEdit;
  $scope.ColumnsHeader = columnsHeaderArticle;
  $scope.Configuration = configuration;
  $scope.CurrentPage = 0;
  $scope.EntriesText = entriesText;
  $scope.Interval = 2;
  $scope.LargeStep = 3;
  $scope.Loading = false;
  $scope.OfText = ofText;
  $scope.PageSize = articleListPageSize;
  $scope.SearchText = searchText;
  $scope.ShowingText = showingText;
  $scope.ShowText = showText;
  $scope.SmallStep = 1;
  $scope.Title = titleArticle;
  $scope.ToText = toText;

  $scope.SelectListBrands = selectListBrands;
  $scope.SelectListFamilies = selectListFamilies;
  $scope.SelectListSubFamilies = selectListSubFamilies;
  $scope.SelectListUnits = selectListUnits;

  $scope.edit = function (line) {
    $scope.Edition = angular.copy(line);
    $('#modalEditionArticle').modal('show');
  };

  $scope.add = function () {
    $scope.Edition = {};
    $('#modalEditionArticle').modal('show');
  };

  $scope.formValid = function () {
    $scope.ValidCode = $scope.Edition !== undefined && $scope.Edition.Code !== undefined && $scope.Edition.Code != '';
    $scope.ValidDesignation = $scope.Edition !== undefined && $scope.Edition.Designation !== undefined && $scope.Edition.Designation != '';
    $scope.ValidStartingDate = $scope.Edition !== undefined && $scope.Edition.StartingDate !== undefined && $scope.Edition.StartingDate != '';
    $scope.ValidArticleFamily = $scope.Edition !== undefined && $scope.Edition.ArticleFamily !== undefined && $scope.Edition.ArticleFamily != '';
    $scope.ValidArticleSubFamily = $scope.Edition !== undefined && $scope.Edition.ArticleSubFamily !== undefined && $scope.Edition.ArticleSubFamily != '';
    $scope.ValidBrand = $scope.Edition !== undefined && $scope.Edition.Brand !== undefined && $scope.Edition.Brand != '';
    $scope.ValidUnit = $scope.Edition !== undefined && $scope.Edition.Unit !== undefined && $scope.Edition.Unit != '';
    return $scope.ValidCode && $scope.ValidDesignation && $scope.ValidStartingDate && $scope.ValidArticleFamily && $scope.ValidArticleSubFamily && $scope.ValidBrand && $scope.ValidUnit;
  };

  $scope.findSubFamilies = function () {
    var result = null;
    if ($scope.Edition !== undefined && $scope.Edition.ArticleFamily !== undefined) {
      result = $filter('find')($scope.SelectListSubFamilies.ArticleFamilies, [{ Key: 'FamilyId', Value: $scope.Edition.ArticleFamily.Id }]);
      if (result != null) {
        result = result.ArticleSubFamilies;
        var selectedSubfamily = $filter('find')(result, [{ Key: 'Id', Value: $scope.Edition.ArticleSubFamily.Id }]);
        if (selectedSubfamily !== undefined && selectedSubfamily != null) {
          $scope.Edition.ArticleSubFamily.Id = selectedSubfamily.Id;
        } else {
          $scope.Edition.ArticleSubFamily.Id = result[0].Id;
        }
      }
    }
    return result;
  }

  $scope.dismissValues = function () {
  };

  $scope.saveValues = function (line) {
    var url = "/Articles/Articles/SetValue";
    var params = {
      article: line
    };

    $http.post(url, params).success(function (data, status) {
      $scope.getValues();
    });
  };

  $scope.deleteValue = function (line) {
    var url = "/Articles/Articles/DeleteValue";
    var params = {
      article: line
    };

    $http.post(url, params).success(function (data, status) {
      if ($scope.DataSource.indexOf(line) > -1) {
        $scope.getValues();
      }
    });
  };

  $scope.getValues = function () {
    $scope.Loading = true;
    var url = "/Articles/Articles/GetValues";
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.DataSource = data;
    }).then(function () {
      $scope.Loading = false;
    });
  };

  $scope.getValues();
}]);