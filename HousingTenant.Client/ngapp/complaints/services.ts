import { complaintModule as mm } from './module';

var complaintService = mm.factory('complaintRequestService', ['$http', function ($http) {
  return {
    getRequestList: function (aptguid, scope, userguid) {
      console.log('GET COMPLAINTS');
      $http.get('http://housingtenantbusiness.azurewebsites.net/api/request/id?=' + aptguid).then(
        function (res) {
          console.log(res.data);
          scope.reqList = [];
          res.data.forEach(element => {
            console.log(element);
            if (element.type == 0 && element.initiator.personId == userguid) {
              scope.reqList.push(element);
            }
          });
        }, function (err) {
          console.log(err);
        });
    },
    postRequest: function (request) {
      $http({
        method: 'POST',
        url: 'http://housingtenantbusiness.azurewebsites.net/api/request/complaintrequest/',
        withCredentials: true,
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Content-Type': 'application/json',
          'Access-Control-Allow-Credentials': 'true',
          'Access-Control-Allow-Methods': 'POST'
        },
        data: {request}
      }). then(function(res){
        console.log(res);
      }, function(err){
        console.log(err);
      });
    }
  }
}])