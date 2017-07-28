import { supplyModule as sm } from './module';
import './services';

var supplyController = sm.controller('suppliesCtrl', ['$scope', 'supplyRequestService', '$routeParams', '$mdDialog', function ($scope, supplyRequestService, $routeParams, $mdDialog) {  
      var aptGuid = $routeParams.aptguid; 
      supplyRequestService.getRequestList(aptGuid, $scope);

      $scope.addRequest = function (form) {
            var request = {
                  description : $scope.description,
                  initiator: localStorage.getItem('currentUser'),
                  requestItems: [],
                  datesubmitted: Date.now(),
                  apartmentId: aptGuid,
                  type: 3
            }
            Object.keys(form).forEach(element => {
                  if(form[element] != null && form[element] != undefined &&  form[element].$viewValue == true){
                        request.requestItems.push(form[element].$name)
                  }
            });
            supplyRequestService.postRequest(request);
            $scope.cancel();
      }
      $scope.openModal = function(event) {
            $mdDialog.show({
                  contentElement: '#AddRequestModal',
                  parent: document.body,
                  targetEvent: event,
                  
            });
      };
      $scope.cancel = function(){
            $mdDialog.cancel();
      }

}]);


