﻿app.controller('NomenclatureList', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;

  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = [20, 50, 100, 200];
  $scope.CanCreate = canCreate;
  $scope.CanDelete = canDelete;
  $scope.CanEdit = canEdit;
  $scope.ColumnsHeader = columnsHeaderNomenclature;
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
  $scope.Title = titleNomenclature;
  $scope.ToText = toText;

  $scope.AvailablePagesSizeArticle = [3, 5, 10, 20];
  $scope.ColumnsHeaderArticle = columnsHeaderArticle;
  $scope.CurrentSelectionArticleParent = [];
  $scope.CurrentSelectionArticleChild = [];
  $scope.LoadingArticle = false;
  $scope.PageSizeArticleParent = 3;
  $scope.PageSizeArticleChild = 3;
  $scope.SelectionModeArticle = 'single';

  $scope.edit = function (line) {
    $scope.Edition = angular.copy(line);
    $scope.CurrentSelectionArticleParent = [];
    $scope.CurrentSelectionArticleChild = [];
    $scope.CurrentSelectionArticleParent.push($scope.Edition.ArticleParent.Id);
    $scope.CurrentSelectionArticleChild.push($scope.Edition.ArticleChild.Id);
    $('#modalEditionNomenclature').modal('show');
  };

  $scope.add = function () {
    $scope.Edition = {};
    $scope.CurrentSelectionArticleParent = [];
    $scope.CurrentSelectionArticleChild = [];
    $('#modalEditionNomenclature').modal('show');
  };

  $scope.formValid = function () {
    $scope.ValidQuantityParent = $scope.Edition !== undefined && $scope.Edition.QuantityParent !== undefined && $scope.Edition.QuantityParent != '';
    $scope.ValidCurrentSelectionArticleParent = $scope.Edition !== undefined && $scope.CurrentSelectionArticleParent !== undefined && $scope.CurrentSelectionArticleParent != '';
    $scope.ValidQuantityChild = $scope.Edition !== undefined && $scope.Edition.QuantityChild !== undefined && $scope.Edition.QuantityChild != '';
    $scope.ValidCurrentSelectionArticleChild = $scope.Edition !== undefined && $scope.CurrentSelectionArticleChild !== undefined && $scope.CurrentSelectionArticleChild != '';
    return $scope.ValidQuantityParent && $scope.ValidCurrentSelectionArticleParent && $scope.ValidQuantityChild && $scope.ValidCurrentSelectionArticleChild;
  };

  $scope.dismissValues = function () {
  };

  $scope.saveValues = function (line) {
    var url = "/Articles/Nomenclature/SetValue";
    line.ArticleParent = { Id: $scope.CurrentSelectionArticleParent[0] };
    line.ArticleChild = { Id: $scope.CurrentSelectionArticleChild[0] };
    var params = {
      nomenclature: line
    };

    $http.post(url, params).success(function (data, status) {
      $scope.getValues();
    });
  };

  $scope.delete = function (line) {
    var url = "/Articles/Nomenclature/DeleteValue";
    var params = {
      nomenclature: line
    };

    $http.post(url, params).success(function (data, status) {
      if ($scope.DataSource.indexOf(line) > -1) {
        $scope.getValues();
      }
    });
  };

  $scope.getValues = function () {
    $scope.Loading = true;
    var url = "/Articles/Nomenclature/GetValues";
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.DataSource = data;
      $scope.ItemsCount = $scope.DataSource.length;
    }).then(function () {
      $scope.Loading = false;
    });
  };

  $scope.getValuesArticle = function () {
    $scope.LoadingArticle = true;
    var url = "/Articles/Articles/GetValues";
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.DataSourceArticle = data;
    }).then(function () {
      $scope.LoadingArticle = false;
    });
  };

  $scope.getValues();
  $scope.getValuesArticle();
}]);