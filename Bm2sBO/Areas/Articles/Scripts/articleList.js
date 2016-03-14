app.controller('ArticleList', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;

  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = [20, 50, 100, 200];
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
  $scope.PageSize = 20;
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

  $scope.findSubFamilies = function () {
    var result = null;
    if ($scope.Edition) {
      result = $filter('find')($scope.SelectListSubFamilies.ArticleFamilies, [{ Key: 'FamilyId', Value: $scope.Edition.ArticleFamily.Id }]).ArticleSubFamilies;
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
      result = data;

      var currentLine = $filter('find')($scope.DataSource, [{ Key: 'Id', Value: data.Id }]);
      currentLine.Code = data.Code;
      currentLine.Designation = data.Designation;
      currentLine.StartingDate = data.StartingDate;
      currentLine.ArticleFamily = data.ArticleFamily;
      currentLine.ArticleSubFamily = data.ArticleSubFamily;
      currentLine.Brand = data.Brand;
      currentLine.Unit = data.Unit;
    });
  };

  $scope.deleteValue = function (line) {
    var url = "/Articles/Articles/DeleteValue";
    var params = {
      article: line
    };

    $http.post(url, params).success(function (data, status) {
      result = data;
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