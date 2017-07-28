import { moveModule as mm } from './module';
import './service';
import '../apartment/service';

var moveController = mm.controller('moveCtrl', ['adalAuthenticationService','$scope', '$routeParams', '$mdDialog', 'aptFactory', 'moveService', function (adalAuthenticationService, $scope, $routeParams, $mdDialog, aptFactory, moveService) {
   var aptGuid = $routeParams.aptguid;
   var currentUser = adalAuthenticationService.userInfo.currentUser;

   aptFactory.getListApartments($scope);

   $scope.addMoveRequest = function (form) {
      console.log(form);
      console.log($scope.selectedApartment)
      var request = {
         description: form.reason.$modelValue,
         initiator: currentUser,
         requestedApartmentAddress: $scope.selectedApartmentAddress
      }
      console.log(request);

      moveService.postRequest(request);
      form.$setUntouched();
      $scope.cancel();
   }

   $scope.openModal = function (event) {
      console.log($scope.aptList);
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