import { supplyModule as sm } from './module';
import './services';

var supplyController = sm.controller('suppliesCtrl', ['$scope', 'supplyRequestService', '$routeParams', '$mdDialog', function ($scope, supplyRequestService, $routeParams, $mdDialog) {
      var requestModal = document.getElementById('AddRequestModal');
      
      var aptid = $routeParams.aptid; 
      supplyRequestService.getRequestList(aptid, $scope);

      $scope.addRequest = function (form) {
            var request = {
                  description : $scope.description,
                  initiator : 'Current User',
                  requestItems: [],
                  datesubmitted: Date.now()
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


