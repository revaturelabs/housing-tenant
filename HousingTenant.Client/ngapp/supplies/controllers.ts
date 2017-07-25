import { supplyModule as sm } from './module';
import './services';
import * as angular from 'angular';

var supplyController = sm.controller('suppliesCtrl', ['$scope', 'supplyRequestListSvc', '$routeParams', '$mdDialog', function ($scope, supplyRequestListSvc, $routeParams, $mdDialog) {
      var requestModal = document.getElementById('AddRequestModal');
      
      var aptid = $routeParams.aptid; 
      supplyRequestListSvc.getRequestList(aptid, $scope);
      $scope.addRequest = function (form) {
            console.log(form);
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
            console.log(request);

            supplyRequestListSvc.postRequest(request);
            $scope.cancel();
      }
      $scope.openModal = function(ev) {
            $mdDialog.show({
                  contentElement: '#AddRequestModal',
                  parent: angular.element(document.body),
                  targetEvent: ev,
                  
            });
      };
      $scope.cancel = function(){
            $mdDialog.cancel();
      }

}]);


