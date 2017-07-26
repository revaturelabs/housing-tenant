import { maintenanceModule as mm } from './module';
import './services';

var maintenanceController = mm.controller('maintenanceCtrl', ['$scope', 'maintenanceRequestService', '$routeParams', '$mdDialog', function ($scope, maintenanceRequestService, $routeParams, $mdDialog) {
  var aptGuid = $routeParams.aptguid;

  $scope.maintenanceTypes = [
    'Electrical Issues',
    'Slow Internet',
    'No Internet',
    'Plumbing: Kitchen',
    'Plumbing: Bathroom',
    'Heating, Ventilation, and Air Conditioning',
    'Other'
    ];

    $scope.otherSelected = "visibility: hidden;"

    $scope.otherDescription = function(type){
      if(type == 'Other'){
        $scope.otherSelected = "visibility: visible;";
      }
    }

  maintenanceRequestService.getRequestList(aptGuid, $scope);

  $scope.addMaintenanceRequest = function () {
    var request = {
      description: $scope.description,
      initiator: 'Current User',
      datesubmitted: Date.now(),
      urgent: $scope.urgent,
      type: 1
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