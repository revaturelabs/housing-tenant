import './services';
import '../apartment/service';

import { complaintModule as cm } from './module';

var complaintController = cm.controller('complaintCtrl', ['aptFactory', 'complaintRequestService', '$routeParams', '$scope', '$mdDialog', function (aptFactory, complaintRequestService, $routeParams, $scope, $mdDialog) {
   var aptGuid = $routeParams.aptguid;
   var initiatorId = 0;

   complaintRequestService.getRequestList(aptGuid, $scope, initiatorId);
   aptFactory.getApartmentByGuid($scope, aptGuid);

   $scope.addComplaintRequest = function (form) {
      var request = {
         accused: form.accussed.$modelValue,
         description: form.description.$modelValue,
         initiator: 'Current User',
         datesubmitted: Date.now(),
         urgent: true
      }

      complaintRequestService.postRequest(request);
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