import { supplyModule as sm } from './module';

var supplyService = sm.factory('supplyRequestService', ['$http', function ($http) {
      return {
            getRequestList: function (aptidstring, scope) {
                  console.log(aptidstring);
                  $http.get('http://housingtenantbusiness.azurewebsites.net/api/request/id?='+ aptidstring).then(
                        function (res) {
                              scope.reqList = [];
                              res.data.forEach(element => {
                                    if (element.type === "SupplyRequest") {
                                          scope.reqList.push(element);
                                    }
                              });
                              console.log(scope.reqList);
                        }, function (err) {
                              console.log(err);
                        });
            },
            postRequest: function (request) {
                  console.log(request);
                  $http({
                        method: 'POST',
                        url: 'http://housingtenantbusiness.azurewebsites.net/api/request/supplyrequest/',
                        withCredentials: true,
                        headers: {
                              'Access-Control-Allow-Origin': '*',
                              'Content-Type': 'application/json',
                              'Access-Control-Allow-Credentials': 'true',
                              'Access-Control-Allow-Methods': 'POST'
                        },
                        data: { request }
                  }).then(function (res) {
                        console.log(res);
                  }, function (err) {
                        console.log(err);
                  });
            }
      };
}]);