import { supplyModule as sm } from './module';
import './services';

var supplyController = sm.controller('suppliesCtrl', ['adalAuthenticationService', '$scope', 'supplyRequestService', '$routeParams', '$mdDialog', function (adalAuthenticationService, $scope, supplyRequestService, $routeParams, $mdDialog) {
      var aptGuid = $routeParams.aptguid;
      var currentUser = adalAuthenticationService.userInfo.currentUser;
      supplyRequestService.getRequestList(aptGuid, $scope);
      console.log(currentUser);
      $scope.addRequest = function (form) {
            var request = {
                  status: 'Pending',
                  apartmentId: aptGuid,
                  description: $scope.description,
                  initiator: currentUser,
                  requestItems: [],
                  apartmentId: aptGuid
            }
            Object.keys(form).forEach(element => {
                  if (form[element] != null && form[element] != undefined && form[element].$viewValue == true) {
                        request.requestItems.push(form[element].$name)
                  }
            });
            supplyRequestService.postRequest(request, $scope);
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

}]);


