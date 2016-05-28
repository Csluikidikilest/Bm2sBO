app.controller('PartnerList', ['$scope', '$http', '$compile', '$filter', function ($scope, $http, $compile, $filter) {
  $scope.Math = window.Math;

  $scope.AlwaysShowFirstLastButtons = true;
  $scope.AvailablePagesSize = partnerListAvailablePagesSize;
  $scope.CanCreate = canCreate;
  $scope.CanDelete = canDelete;
  $scope.CanEdit = canEdit;
  $scope.ColumnsHeader = columnsHeaderPartner;
  $scope.Configuration = configuration;
  $scope.CurrentPage = 0;
  $scope.EntriesText = entriesText;
  $scope.Interval = 2;
  $scope.LargeStep = 3;
  $scope.Loading = false;
  $scope.OfText = ofText;
  $scope.OrderColumn = $scope.ColumnsHeader[0].Key;
  $scope.OrderReverse = false;
  $scope.PageSize = partnerListPageSize;
  $scope.SearchText = searchText;
  $scope.ShowingText = showingText;
  $scope.ShowText = showText;
  $scope.SmallStep = 1;
  $scope.Title = titlePartner;
  $scope.ToText = toText;

  $scope.CustomActionsPartner = customActionsPartner;

  $scope.AvailablePagesSizePartnerFamilies = partnerFamiliesSelectionAvailablePagesSize;
  $scope.ColumnsHeaderPartnerFamilies = columnsHeaderPartnerFamilies;
  $scope.CurrentSelectionPartnerParentFamilies = [];
  $scope.LoadingPartnerFamilies = false;
  $scope.PageSizePartnerParentFamilies = partnerFamiliesSelectionPageSize;
  $scope.SelectionModePartnerFamilies = 'multiple';
  $scope.TriStatePartnerFamilies = false;

  $scope.AvailablePagesSizeUser = userSelectionAvailablePagesSize;
  $scope.ColumnsHeaderUser = columnsHeaderUser;
  $scope.LoadingUser = false;
  $scope.PageSizeUser = userSelectionPageSize;
  $scope.SelectionModeUser = 'single';
  $scope.TriStateUser = false;

  $scope.add = function () {
    $scope.Edition = {};
    $('#modalEditionArticle').modal('show');
  };

  $scope.customAction = function (event, line) {
    switch (event.toLowerCase()) {
      case 'website':
        window.open(line.WebSite, '_blank');
        break;
      case 'mail':
        window.location.href = 'mailto:' + line.Email;
        break;
    };
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

  $scope.dismissValues = function () { };

  $scope.edit = function (line) {
    $scope.Edition = angular.copy(line);
    $scope.getValuesContact($scope.Edition.Id);
    $scope.getPartnerPartnerFamilies($scope.Edition.Id);
    $('#modalEditionPartner').modal('show');
  };

  $scope.formValid = function () {
    $scope.ValidCode = $scope.Edition !== undefined && $scope.Edition.Code !== undefined && $scope.Edition.Code !== '';
    $scope.ValidStartingDate = $scope.Edition !== undefined && $scope.Edition.StartingDate !== undefined && $scope.Edition.StartingDate !== '';
    return $scope.ValidCode && $scope.ValidStartingDate;
  };

  $scope.getPartnerPartnerFamilies = function (partnerId) {
    $scope.LoadingPartnerFamilies = true;
    var url = "/Partners/Partners/GetPartnerPartnerFamilies";
    var params = {
      partnerId: partnerId
    };

    $http.post(url, params).success(function (data, status) {
      $scope.CurrentSelectionPartnerParentFamilies = data;
    }).then(function () {
      $scope.LoadingPartnerFamilies = false;
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

  $scope.getValues = function () {
    $scope.Loading = true;
    var url = "/Partners/Partners/GetValues";
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.DataSource = data;
    }).then(function () {
      $scope.Loading = false;
    });
  };

  $scope.getValuesContact = function (partnerId) {
    var url = "/Partners/Partners/GetPartnerContacts";
    var params = {
      partnerId: partnerId
    };

    $http.post(url, params).success(function (data, status) {
      $scope.DataSourceContact = data;
    });
  }

  $scope.getValuesFamilies = function () {
    $scope.Loading = true;
    var url = "/Partners/PartnerFamilies/GetValues";
    var params = {
    };

    $http.post(url, params).success(function (data, status) {
      $scope.DataSourcePartnerFamilies = data;
    }).then(function () {
      $scope.Loading = false;
    });
  };

  $scope.saveValues = function (line) {
    var url = "/Partners/Partners/SetValue";
    var params = {
      partner: line,
      contacts: [],
      partnerPartnerFamiliesId: $scope.CurrentSelectionPartnerParentFamilies
    };

    $http.post(url, params).success(function (data, status) {
      $scope.getValues();
    });
  };

  $scope.getValues();
  $scope.getValuesFamilies();
  $scope.getUsers();
}]);