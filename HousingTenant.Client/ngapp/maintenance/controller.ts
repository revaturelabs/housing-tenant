import { maintenanceModule as mm } from './module';
import './services';

var maintenanceController = mm.controller('maintenanceCtrl', ['$scope', 'maintenanceRequestListSvc', function ($scope, maintenanceRequestListSvc){

  var requestModal = document.getElementById('AddRequestModal');

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
}])