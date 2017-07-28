import { apartmentModule as am } from './module';


var appartmentService = am.factory('aptFactory', ['$http', function ($http) {
  return {
    getApartment: function (scope, address, getPie) {
      $http.get('http://housingtenantbusiness.azurewebsites.net/api/apartment/address/', { params: address }).then(
        function (res) {
          scope.apartment = res.data;
          scope.supplyReq = 0;
          scope.maintenanceReq = 0;
          scope.complaintReq = 0;
          scope.moveReq = 0;
          scope.apartment.requests.forEach(element => {
            if (element.type == 'ComplaintRequest') {
              scope.complaintReq++
            } else if (element.type == 'MaintenanceRequest') {
              scope.maintenanceReq++;
            } else if (element.type == 'MoveRequest') {
              scope.MoveReq++;
            } else if (element.type == 'SupplyRequest') {
              scope.supplyReq++;
            };
          });

          var currentData = [{ label: 'Co', count: scope.complaintReq }, { label: 'Ma', count: scope.maintenanceReq }, { label: 'Mo', count: scope.moveReq }, { label: 'Su', count: scope.supplyReq }];

          if (getPie != 1) {
            getPie(currentData);
          }


          console.log(scope.apartment);
        }, function (err) {
          console.log(err);
        }
      );
    },
    getApartmentByGuid: function (scope, aptguid, getPie) {
      $http.get('http://housingtenantbusiness.azurewebsites.net/api/apartment/id?=' + aptguid).then(
        function (res) {
          scope.apartment = res.data;
          scope.supplyReq = 0;
          scope.maintenanceReq = 0;
          scope.complaintReq = 0;
          scope.moveReq = 0;
          scope.apartment.requests.forEach(element => {
            if (element.type == 'ComplaintRequest') {
              scope.complaintReq++
            } else if (element.type == 'MaintenanceRequest') {
              scope.maintenanceReq++;
            } else if (element.type == 'MoveRequest') {
              scope.MoveReq++;
            } else if (element.type == 'SupplyRequest') {
              scope.supplyReq++;
            };
          });
          var currentData = [{ label: 'Co', count: scope.complaintReq }, { label: 'Ma', count: scope.maintenanceReq }, { label: 'Mo', count: scope.moveReq }, { label: 'Su', count: scope.supplyReq }];
          
          if (getPie != 1) {
            getPie(currentData);
          }
          
          console.log(scope.apartment);
        }, function (err) {
          console.log(err);
        });
    },
    getListApartments: function (scope) {
      $http.get('http://housingtenantbusiness.azurewebsites.net/api/apartment').then(
        function (res) {
          scope.aptList = res.data;
          console.log(scope.aptList);
        }, function (err) {
          console.log(err);
        }
      )
    }
  };
}]);