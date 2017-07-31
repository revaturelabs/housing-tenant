import { maintenanceModule as mm } from './module';
import './services';

var maintenanceController = mm.controller('maintenanceCtrl', ['adalAuthenticationService', '$scope', 'maintenanceRequestService', '$routeParams', '$mdDialog', function (adalAuthenticationService, $scope, maintenanceRequestService, $routeParams, $mdDialog) {
  var aptGuid = $routeParams.aptguid;
  var currentUser = adalAuthenticationService.userInfo.currentUser;

  $scope.maintenanceTypes = [
    'Electrical Issues',
    'Slow Internet',
    'No Internet',
    'Plumbing: Kitchen',
    'Plumbing: Bathroom',
    'Heating, Ventilation, and Air Conditioning',
    'Other'
  ];

  $scope.checkDescription = function () {
    if ($scope.description == 'Other') {
      return true;
    }
    return false;
  }

  maintenanceRequestService.getRequestList(aptGuid, $scope);

  $scope.addMaintenanceRequest = function (form) {
    var request = {
      status: 'Pending',
      apartmentId: aptGuid,
      description: "",
      initiator: currentUser,
      urgent: form.urgent.$modelValue
    }
    if ($scope.checkDescription() == true) {
      request.description = form.customDescription.$modelValue;
    } else {
      request.description = form.description.$modelValue;
    }

    maintenanceRequestService.postRequest(request, $scope);
    $scope.customDescription = "";
    $scope.cancel();
  }

  $scope.openModal = function (event) {
    $mdDialog.show({
      contentElement: '#AddRequestModal',
      parent: document.body,
      targetEvent: event,

    });
  };
  $scope.cancel = function () {
    $mdDialog.cancel();
  }

}])