import { supplyModule as sm } from './module';
import './services';

var supplyController = sm.controller('suppliesCtrl', ['$scope', 'supplyRequestListSvc', '$routeParams', function ($scope, supplyRequestListSvc, $routeParams) {
      var requestModal = document.getElementById('AddRequestModal');
      
      var aptid = $routeParams.aptid; 
      supplyRequestListSvc.getRequestList(aptid, $scope);

      $scope.addRequest = function (d, s, tp, pt, ds, tb, dd, sp) {
            var request = {
                  description : d,
                  initiator : 'Current User',
                  requestItems: [],
                  datesubmitted: Date.now()
            };
            if (s == true){
                  request.requestItems.push('Soap')
            }
            if (tp == true){
                  request.requestItems.push('Toilet Paper');
            }
            if (pt == true){
                  request.requestItems.push('Paper Towels')
            }
            if (ds == true){
                  request.requestItems.push('Dishwasher Soap');
            }
            if (tb == true){
                  request.requestItems.push('Trash Bags')
            }
            if (dd == true){
                  request.requestItems.push('Dish Soap');
            }
            if (sp == true){
                  request.requestItems.push('Sponges');
            }            

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


