import { apartmentModule as am } from './module';
import './service';

var address = {
   Address1: "2100 Wilkes Court",
   Address2: "",
   ApartmentNumber: "102",
   City: "Herndon",
   State: "Virginia",
   ZipCode: "20170"
};


var apartmentController = am.controller('aptCtrl', ['$scope', 'aptFactory', function ($scope, aptFactory) {
   var requestModal;

   aptFactory.getApartment($scope, address);

   // $scope.openModal = function (reqModalId) {
   //    requestModal = document.getElementById(reqModalId);
   //    requestModal.style.display = 'block';
   // }
   // $scope.closeModal = function (reqModalId) {
   //    requestModal = document.getElementById(reqModalId);
   //    requestModal.style.display = 'none';
   // }
   // window.onclick = function (event) {
   //    if (event.target == requestModal) {
   //       requestModal.style.display = 'none';
   //    }
   // }
}]);