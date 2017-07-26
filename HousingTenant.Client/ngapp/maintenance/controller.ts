import { maintenanceModule as mm } from './module';
import './services';

var maintenanceController = mm.controller('maintenanceCtrl', ['$scope', 'maintenanceRequestService', '$routeParams', '$mdDialog', function ($scope, maintenanceRequestService, $routeParams, $mdDialog) {
  var aptGuid = $routeParams.aptguid;

  //$scope.description = "";

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

  $scope.addMaintenanceRequest = function () {
    $scope.customDescription = "untouched";
    $scope.urgent = false;
    
    var request = {
      description: "",
      initiator: 'Current User',
      datesubmitted: Date.now(),
      urgent: $scope.urgent,
      type: 1
    }
    if ($scope.checkDescription() == true) {
      console.log($scope.customDescription);
      request.description = $scope.customDescription;
    } else {
      request.description = $scope.description;
    }

    console.log(request);

    maintenanceRequestService.postRequest(request);
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