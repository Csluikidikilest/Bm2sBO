app.controller('Translation', ['$scope', '$http', '$filter', function ($scope, $http, $filter) {
  $scope.Math = window.Math;

  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = [20, 50, 100, 200];
  $scope.CanCreate = false;
  $scope.CanDelete = false;
  $scope.CanEdit = canEdit;
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
  $scope.Title = titleTranslation;
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
    $scope.ColumnsHeader = columnsHeaderTranslations;
    angular.forEach($scope.Languages, function (value, key) {
      $scope.ColumnsHeader.push({ "Key": value.Code, "Value": value.Name, "Editable": true, Type: 'text', "Required": false });
    });
  };

  $scope.getLanguagesValues = function () {
    $scope.Loading = true;
    var url = "Translations/GetLanguagesValues";
    var result;
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.Languages = data;
      $scope.generateColumnsHeader();
      $scope.getValues();
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
    }).then(function () {
      $scope.Loading = false;
    });
  };

  $scope.getLanguagesValues();
}]);