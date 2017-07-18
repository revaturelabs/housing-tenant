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

   constructor(n:string){
      this.Name = n;   
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
   $scope.requestList = [
      new Request('First Request'), new Request('Second Request'), new Request('Third Request')
   ]; 
}]);