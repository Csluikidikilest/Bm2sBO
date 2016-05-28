app.controller('GroupList', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;

  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = [20, 50, 100, 200];
  $scope.CanCreate = canCreate;
  $scope.CanDelete = canDelete;
  $scope.CanEdit = canEdit;
  $scope.ColumnsHeader = columnsHeaderGroup;
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
  $scope.Title = titleGroup;
  $scope.ToText = toText;

  $scope.AvailablePagesSizeUser = [3, 5, 10, 20];
  $scope.ColumnsHeaderUser = columnsHeaderUser;
  $scope.CurrentSelectionUser = [];
  $scope.LoadingUser = false;
  $scope.PageSizeUser = 3;
  $scope.SelectionModeUser = 'multiple';
  $scope.TriStateUser = false;

  $scope.edit = function (line) {
    $scope.Edition = angular.copy(line);
    $scope.getUsersGroup($scope.Edition.Id);
    $('#modalEditionGroup').modal('show');
  };

  $scope.dismissValues = function () {
  };

  $scope.saveValues = function (line) {
    var url = "/Users/Groups/SetValue";

    var params = {
      group: line,
      usersId: $scope.CurrentSelectionUser
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
    var url = "/Users/Groups/DeleteValue";
    var params = {
      group: line
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
    var url = "/Users/Groups/GetValues";
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

  $scope.getUsersGroup = function (groupId) {
    $scope.LoadingUser = true;
    var url = "/Users/Groups/GetUsersGroup";
    var params = {
      groupId: groupId
    };

    $http.post(url, params).success(function (data, status) {
      $scope.CurrentSelectionUser = data;
    }).then(function () {
      $scope.LoadingUser = false;
    });
  };

  $scope.getValues();
  $scope.getUsers();
}]);