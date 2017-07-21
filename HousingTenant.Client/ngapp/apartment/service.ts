import {apartmentModule as am} from './module';


var appartmentService = am.factory('aptFactory', ['$http', function($http){
   return{
      getApartment : function(scope,address){
         $http.get('http://localhost:5000/api/values/', {params: address}).then(
            function(res){
               console.log(res);
               scope.apartment = res.data;
            },function(err){
               console.log(err);
               scope.apartment = {};
               scope.apartment.address = address;
               scope.apartment.beds = 3;
               scope.apartment.bathrooms = 2;
               scope.apartment.complexname = 'Westerly At Worldgate';
               scope.apartment.people = [
                  {
                     firstname: 'Julian',
                     lastname: 'Rojas'
                  },
                  {
                     firstname: 'Jameson',
                     lastname: 'Bruuuhhh'
                  }
               ];
               scope.apartment.requests = [
                  {
                     soap : true,
                     toiletPaper : true,
                     paperTowels : true,
                     dishSoap : true,
                     trashBags : true,
                     dishwasherDetergent : true,
                     sponges : true,
                     type : 1
                  },
                  {
                     soap : true,
                     toiletPaper : false,
                     paperTowels : true,
                     dishSoap : false,
                     trashBags : true,
                     dishwasherDetergent : false,
                     sponges : true,
                     type : 1
                  },
                  {
                     soap : false,
                     toiletPaper : false,
                     paperTowels : false,
                     dishSoap : false,
                     trashBags : false,
                     dishwasherDetergent : false,
                     sponges : true,
                     type : 1
                  },
                  {
                     type : 2
                  },
                  {
                     type : 3
                  }
               ];
               scope.supplyReq = 0;
               scope.maintenanceReq = 0;
               scope.complaintReq = 0;
               scope.apartment.requests.forEach(element => {
                  if(element.type == 1){
                     scope.supplyReq++;
                     console.log(scope.maintenanceReq);
                  }else if(element.type == 2){
                     scope.maintenanceReq++;
                     console.log(scope.maintenanceReq);
                  }else{
                     scope.complaintReq++;
                     console.log(scope.complaintReq);
                  };
               });
               console.log(scope.apartment);
            }
         );
      }
   };
}]);