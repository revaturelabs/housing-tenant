import { maintenanceModule as mm } from './module';

var maintenanceService = mm.factory('maintenanceRequestService', ['$http', function ($http) {
  return {
    getRequestList: function (aptguid, scope) {
      $http.get('http://housingtenantbusiness.azurewebsites.net/api/request/id?=' + aptguid).then(
        function (res) {
          scope.reqList = [];
          res.data.forEach(element => {
            if (element.type === "MaintenanceRequest") {
              scope.reqList.push(element);
            }
          });
        }, function (err) {
          console.log(err);
        });
    },
    postRequest: function (request, scope) {
      $http({
        method: 'POST',
        url: 'http://housingtenantbusiness.azurewebsites.net/api/request/maintenancerequest/',
        //url: 'http://localhost:53254/api/request/maintenancerequest/',
        withCredentials: true,
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Content-Type': 'application/json',
          'Access-Control-Allow-Credentials': 'true',
          'Access-Control-Allow-Methods': 'POST'
        },
        data: JSON.stringify(request)
      }).then(function (res) {
        request.dateSubmitted = 'Today';
        request.status = 'Pending';
        scope.reqList.push(request);
        console.log(res);
      }, function (err) {
        console.log(err);
      });
    }
  }
}])