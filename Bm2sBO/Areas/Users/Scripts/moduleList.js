app.controller('ModuleList', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;

  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = [20, 50, 100, 200];
  $scope.CanCreate = canCreate;
  $scope.CanDelete = canDelete;
  $scope.CanEdit = canEdit;
  $scope.ColumnsHeader = columnsHeaderModule;
  $scope.Configuration = configuration;
  $scope.CurrentPage = 0;
  $scope.EntriesText = entriesText;
  $scope.Interval = 2;
  $scope.LargeStep = 3;
  $scope.Loading = false;
  $scope.OfText = ofText;
  $scope.OrderColumn = $scope.ColumnsHeader[0].Key;
  $scope.OrderReverse = false;
  $scope.PageSize = 20;
  $scope.SearchText = searchText;
  $scope.ShowingText = showingText;
  $scope.ShowText = showText;
  $scope.SmallStep = 1;
  $scope.Title = titleModule;
  $scope.ToText = toText;

  $scope.AvailablePagesSizeUser = [3, 5, 10, 20];
  $scope.ColumnsHeaderUser = columnsHeaderUser;
  $scope.CurrentSelectionUser = [];
  $scope.LoadingUser = false;
  $scope.PageSizeUser = 3;
  $scope.SelectionModeUser = 'multiple';

  $scope.AvailablePagesSizeGroup = [3, 5, 10, 20];
  $scope.ColumnsHeaderGroup = columnsHeaderGroup;
  $scope.CurrentSelectionGroup = [];
  $scope.LoadingGroup = false;
  $scope.PageSizeGroup = 3;
  $scope.SelectionModeGroup = 'multiple';

  $scope.edit = function (line) {
    $scope.Edition = angular.copy(line);
    $('#modalEditionModule').modal('show');
  };

  $scope.dismissValues = function () {
  };

  $scope.saveValues = function (line) {
    var url = "/Users/Modules/SetValue";

    var params = {
      module: line,
      usersId: $scope.CurrentSelectionUser,
      groupsId: $scope.CurrentSelectionGroup
    };

    $http.post(url, params).success(function (data, status) {
      result = data;

      var currentLine = $filter('find')($scope.DataSource, [{ Key: 'Id', Value: data.Id }]);
      currentLine.Code = data.Code;
      currentLine.Name = data.Name;
      currentLine.StartingDate = data.StartingDate;
    });
  };

  $scope.deleteValue = function (line) {
    var url = "/Users/Modules/DeleteValue";
    var params = {
      module: line
    };

    $http.post(url, params).success(function (data, status) {
      var index = $scope.DataSource.indexOf(line);
      if (index > -1) {
        $scope.getValues();
      }
    });
  };

  $scope.getValues = function () {
    $scope.Loading = true;
    var url = "/Users/Modules/GetValues";
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.DataSource = data;
      $scope.ItemsCount = $scope.DataSource.length;
    }).then(function () {
      $scope.Loading = false;
    });
  };

  $scope.getUsers = function () {
    $scope.LoadingUser = true;
    var url = "/Users/Users/GetValues";
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.DataSourceUser = data;
    }).then(function () {
      $scope.LoadingUser = false;
    });
  };

  $scope.getGroups = function () {
    $scope.LoadingGroup = true;
    var url = "/Users/Groups/GetValues";
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.DataSourceGroup = data;
    }).then(function () {
      $scope.LoadingGroup = false;
    });
  };

  $scope.getValues();
  $scope.getUsers();
  $scope.getGroups();
}]);