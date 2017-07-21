import { supplyModule as sm } from './module';
import './services';

var supplyController = sm.controller('suppliesCtrl', ['$scope', 'supplyRequestListSvc', '$routeParams', function ($scope, supplyRequestListSvc, $routeParams) {
      var requestModal = document.getElementById('AddRequestModal');
      
      var aptid = $routeParams.aptid; 
      supplyRequestListSvc.getRequestList(aptid, $scope);

      $scope.addRequest = function (n, s, tp, pt, ds, tb, dd, sp) {
            var request = {
                  name: n,
                  soap: s,
                  toiletPaper: tp,
                  paperTowels: pt,
                  dishSoap: ds,
                  trashBags: tb,
                  dishwasherDetergent: dd,
                  sponges: sp,
                  requestType : 1
            };

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


