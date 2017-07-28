import './services';
import '../apartment/service';

import { complaintModule as cm } from './module';

var complaintController = cm.controller('complaintCtrl', ['adalAuthenticationService', 'aptFactory', 'complaintRequestService', '$routeParams', '$scope', '$mdDialog', function (adalAuthenticationService, aptFactory, complaintRequestService, $routeParams, $scope, $mdDialog) {
   var aptGuid = $routeParams.aptguid;
   var currentUser = adalAuthenticationService.userInfo.currentUser

   complaintRequestService.getRequestList(aptGuid, $scope, currentUser.personDTOId);
   aptFactory.getApartmentByGuid($scope, localStorage.getItem('aptGuid'), 1);

   $scope.addComplaintRequest = function (form) {
      console.log(form);
      var request = {
         accused: form.accused.$modelValue,
         description: form.description.$modelValue,
         initiator: currentUser,
         urgent: true
      }

      complaintRequestService.postRequest(request);
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