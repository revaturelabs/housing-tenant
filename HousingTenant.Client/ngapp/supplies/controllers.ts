import { supplyModule as sm } from './module';
import './services';

var supplyController = sm.controller('suppliesCtrl', ['$scope', 'supplyRequestListSvc', '$routeParams', function ($scope, supplyRequestListSvc, $routeParams) {
      var requestModal = document.getElementById('AddRequestModal');
      
      var aptid = $routeParams.aptid; 
      supplyRequestListSvc.getRequestList(aptid, $scope);
            //delivers
      $scope.addRequest = function (form) {
            var request = {
                  description : $scope.description,
                  initiator : 'Current User',
                  requestItems: [],
                  datesubmitted: Date.now()
            }

            form.forEach(element => {
                  if(element.$viewValue == true){
                        request.requestItems.push(element.$name)
                  }
            });        

            console.log(form);
            console.log(request);

            supplyRequestListSvc.postRequest(request);
            $scope.closeModal();
      }

      $scope.openModal = function () {
            requestModal.style.display = 'block';
      }

      $scope.closeModal = function () {
            requestModal.style.display = 'none';
      }
      window.onclick = function (event) {
            if (event.target == requestModal) {
                  requestModal.style.display = 'none';
            }
      }
}]);


