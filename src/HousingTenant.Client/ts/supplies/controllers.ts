import {supplyModule as sm} from './module';

class Request {
   Name: string;
   Soap: boolean;
   ToiletPaper : boolean;
   PaperTowels : boolean;
   DishSoap : boolean;
   TrashBags : boolean;
   DishwasherDetergent : boolean;
   Sponges : boolean;

   constructor(){
      this.Name = " ";   
      this.Soap = true;
      this.ToiletPaper = false;
      this.PaperTowels = false;
      this.DishSoap = true;
      this.TrashBags = false;
      this.DishwasherDetergent = false;
      this.Sponges = false;
   }
}


var supplyController = sm.controller('suppliesCtrl', ['$scope', function($scope){
   
   var requestModal = document.getElementById('AddRequestModal');
   
   var req1 = new Request;
   req1.Name = 'First Request';
   var req2 = new Request;
   req2.Name = 'Second Request';
   var req3 = new Request;
   req3.Name = 'Third Request';

   $scope.requestList = [];
   $scope.requestList.push(req1);
   $scope.requestList.push(req2);
   $scope.requestList.push(req3);

   $scope.addRequest = function(n,s,tp,pt,ds,tb,dd,sp){
      var request = {
            Name: n,
            Soap: s,
            ToiletPaper : tp,
            PaperTowels : pt,
            DishSoap : ds,
            TrashBags : tb,
            DishwasherDetergent : dd,
            Sponges : sp
      }
      $scope.requestList.push(request);
      $scope.closeModal();

      console.log($scope.requestList);
   }

   $scope.openModal = function(){
      requestModal.style.display = 'block';
   }

   $scope.closeModal = function(){
      requestModal.style.display = 'none';
   }
   window.onclick = function(event){
      if(event.target == requestModal){
         requestModal.style.display = 'none';
      }
   }
}]);


