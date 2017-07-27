import {moveModule as mm} from './module';
import './service';
import '../apartment/service';

var moveController = mm.controller('moveCtrl', ['$scope', '$routeParams','$mdDialog', 'aptFactory', 'moveService', function($scope, $routeParams, $mdDialog, aptFactory, moveService){
   var aptGuid = $routeParams.aptguid;
   var userGuid = 2;
   aptFactory.getListApartments($scope);

   $scope.addMoveRequest = function(form){
      var request = {
         description: form.reason.$modelValue,
         initiator: 'currentUser',
         datesubmitted: Date.now(),
         requestedApartmentAddress: form.apartment.$modelValue
      }
      moveService.postRequest(request);

      form.$setUntouched();
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