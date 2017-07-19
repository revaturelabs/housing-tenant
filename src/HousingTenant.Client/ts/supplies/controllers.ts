import { supplyModule as sm } from './module';
import './services';

var supplyController = sm.controller('suppliesCtrl', ['$scope', 'supplyRequestListSvc', function ($scope, supplyRequestListSvc) {

      var requestModal = document.getElementById('AddRequestModal');

      var address = {
            Address1: "123 main",
            Address2: "suit",
            ApartmentNumber: "302",
            City: "Reston",
            State: "Florida",
            ZipCode: "32792"
      };

      supplyRequestListSvc.getRequestList(address, $scope);

      $scope.addRequest = function (n, s, tp, pt, ds, tb, dd, sp) {
            var request = {
                  name: n,
                  soap: s,
                  toiletPaper: tp,
                  paperTowels: pt,
                  dishSoap: ds,
                  trashBags: tb,
                  dishwasherDetergent: dd,
                  sponges: sp
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


