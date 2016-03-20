app.controller('UserList', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;

  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = [20, 50, 100, 200];
  $scope.CanCreate = canCreate;
  $scope.CanDelete = canDelete;
  $scope.CanEdit = canEdit;
  $scope.ColumnsHeader = columnsHeaderUser;
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
  $scope.Title = titleBrand;
  $scope.ToText = toText;

  $scope.AvailablePagesSizeGroup = [3, 5, 10, 20];
  $scope.ColumnsHeaderGroup = columnsHeaderGroup;
  $scope.CurrentSelectionGroup = [];
  $scope.LoadingGroup = false;
  $scope.PageSizeGroup = 3;
  $scope.SelectionModeGroup = 'multi';

  $scope.edit = function (line) {
    $scope.Edition = angular.copy(line);
    $scope.getGroupsUser($scope.Edition.Id);
    $('#modalEditionUser').modal('show');
  };

  $scope.dismissValues = function () {
  };

  $scope.saveValues = function (line) {
    var url = "/Users/Users/SetValue";
    var params = {
      user: line,
      GroupsId: $scope.CurrentSelectionGroup
    };

    $http.post(url, params).success(function (data, status) {
      $scope.getValues();
    });
  };

  $scope.deleteValue = function (line) {
    var url = "/Users/Users/DeleteValue";
    var params = {
      user: line
    };

    $http.post(url, params).success(function (data, status) {
      if ($scope.DataSource.indexOf(line) > -1) {
        $scope.getValues();
      }
    });
  };

  $scope.getValues = function () {
    $scope.Loading = true;
    var url = "/Users/Users/GetValues";
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.DataSource = data;
      $scope.ItemsCount = $scope.DataSource.length;
    }).then(function () {
      $scope.Loading = false;
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

  $scope.getGroupsUser = function (userId) {
    $scope.LoadingGroup = true;
    var url = "/Users/Users/GetGroupsUser";
    var params = {
      userId: userId
    };

    $http.post(url, params).success(function (data, status) {
      $scope.CurrentSelectionGroup = data;
    }).then(function () {
      $scope.LoadingGroup = false;
    });
  };

  $scope.getValues();
  $scope.getGroups();
}]);