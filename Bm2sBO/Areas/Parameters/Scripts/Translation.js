app.controller('Translation', ['$scope', '$http', '$compile', '$filter', '$localStorage', '$sessionStorage', function ($scope, $http, $compile, $filter, $localStorage, $sessionStorage) {
  $scope.Math = window.Math;
  $scope.Languages = languages.Languages;
  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = [20, 50, 100, 200];
  $scope.LargeStep = 3;
  $scope.PageSize = 20;
  $scope.Interval = 2;
  $scope.SmallStep = 1;

  $scope.CanCreate = false;
  $scope.CanDelete = false;
  $scope.CanEdit = canEdit;

  $scope.EntriesText = entriesText;
  $scope.OfText = ofText;
  $scope.SearchText = searchText;
  $scope.ShowingText = showingText;
  $scope.ShowText = showText;
  $scope.Title = title;
  $scope.ToText = toText;

  $scope.edit = function (line) {
    $scope.Edition = angular.copy(line);
    $('#modalEdition').modal('show');
  };

  $scope.dismissValues = function () {
  };

  $scope.saveValues = function (line) {
    var url = "/Translations/SetValue";
    angular.forEach($scope.Languages, function (language, languageKey) {
      var params = {
        screen: line.screen,
        key: line.key,
        languageCode: language.Code,
        value: line[language.Code]
      };

      $http.post(url, params).success(function (data, status) {
        result = data;
      });
    })

    var currentLine = $filter('find')($scope.DataSource, [{ Key: 'screen', Value: line.screen }, { Key: 'key', Value: line.key }]);

    angular.forEach($scope.Languages, function (value, key) {
      currentLine[value.Code] = line[value.Code];
    });
  };

  $scope.generateColumnsHeader = function () {
    $scope.ColumnsHeader = columnsHeader;
    angular.forEach($scope.Languages, function (value, key) {
      $scope.ColumnsHeader.push({ "Key": value.Code, "Value": value.Name, "Editable": true, Type: 'text', "Required": false });
    });
  };

  $scope.getValues = function () {
    var url = "/Translations/GetValues";
    var result;
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.DataSource = [];
      angular.forEach(data, function (line, lineKey) {
        var object = {};
        object['screen'] = line.Screen;
        object['key'] = line.Key;
        angular.forEach(line.Languages, function (language, languageKey) {
          object[language.Code] = language.Translation;
        });
        $scope.DataSource.push(object);
      });
      $scope.ItemsCount = $scope.DataSource.length;
      $scope.jumpToPage(0);
    });
  };

  $scope.jumpToPage = function (currentPage) {
    $scope.CurrentPage = currentPage;
    $scope.refreshPageSize();
  };

  $scope.refreshPageSize = function () {
    $scope.FirstItem = ($scope.CurrentPage * $scope.PageSize) + 1;
    $scope.LastItem = Math.min(($scope.CurrentPage + 1) * $scope.PageSize, $scope.ItemsCount);
    $scope.PagesCount = Math.ceil($scope.ItemsCount / $scope.PageSize);
    $scope.PagesList = [];
    for (i = 1; i <= $scope.PagesCount - 2; i++) {
      $scope.PagesList.push(i);
    };
  };

  $scope.getValues();
  $scope.generateColumnsHeader();
}]);