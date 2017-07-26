import { apartmentModule as am } from './module';


var appartmentService = am.factory('aptFactory', ['$http', function ($http) {
   return {
      getApartment: function (scope, address) {
         $http.get('http://housingtenantbusiness.azurewebsites.net/api/apartment/address/', { params: address }).then(
            function (res) {
               console.log(res);
               scope.apartment = res.data;
               scope.supplyReq = 0;
               scope.maintenanceReq = 0;
               scope.complaintReq = 0;
               scope.apartment.requests.forEach(element => {
                  if (element.type == 1) {
                     scope.supplyReq++;
                     console.log(scope.maintenanceReq);
                  } else if (element.type == 2) {
                     scope.maintenanceReq++;
                     console.log(scope.maintenanceReq);
                  } else {
                     scope.complaintReq++;
                     console.log(scope.complaintReq);
                  };
               });
               console.log(scope.apartment);
            }, function (err) {
               console.log(err);
               scope.apartment = {};
               scope.apartment.address = {
                  address1: "123 main",
                  address2: "suit",
                  apartmentNumber: "302",
                  city: "Reston",
                  state: "Florida",
                  zipCode: "32792"
               };
               scope.apartment.beds = 3;
               scope.apartment.bathrooms = 2;
               scope.apartment.complexName = 'Westerly At Worldgate';
               scope.apartment.persons = [
                  {
                     firstName: 'Julian',
                     lastName: 'Rojas'
                  },
                  {
                     firstName: 'Jameson',
                     lastName: 'Bruuuhhh'
                  }
               ];
               scope.apartment.requests = [
                  {
                     soap: true,
                     toiletPaper: true,
                     paperTowels: true,
                     dishSoap: true,
                     trashBags: true,
                     dishwasherDetergent: true,
                     sponges: true,
                     type: 1
                  },
                  {
                     soap: true,
                     toiletPaper: false,
                     paperTowels: true,
                     dishSoap: false,
                     trashBags: true,
                     dishwasherDetergent: false,
                     sponges: true,
                     type: 1
                  },
                  {
                     soap: false,
                     toiletPaper: false,
                     paperTowels: false,
                     dishSoap: false,
                     trashBags: false,
                     dishwasherDetergent: false,
                     sponges: true,
                     type: 1
                  },
                  {
                     type: 2
                  },
                  {
                     type: 3
                  }
               ];
               scope.supplyReq = 0;
               scope.maintenanceReq = 0;
               scope.complaintReq = 0;
               scope.apartment.requests.forEach(element => {
                  if (element.type == 1) {
                     scope.supplyReq++;
                     console.log(scope.maintenanceReq);
                  } else if (element.type == 2) {
                     scope.maintenanceReq++;
                     console.log(scope.maintenanceReq);
                  } else {
                     scope.complaintReq++;
                     console.log(scope.complaintReq);
                  };
               });
               scope.apartment.guid = '03ae80e1-7227-48ef-8f76-30f5ebf6d89d';
               console.log(scope.apartment);
            }
         );
      }
   };
}]);