import { supplyModule as sm } from './module';

var supplyService = sm.factory('supplyRequestService', ['$http', function ($http) {
      return {
            getRequestList: function (aptidstring, scope) {
                  console.log(aptidstring);
                  $http.get('http://housingtenantbusiness.azurewebsites.net/api/request/id', { params: aptidstring }).then(
                        function (res) {
                              console.log(res.data);
                              scope.reqList = [];
                              res.data.forEach(element => {
                                    console.log(element);
                                    if (element.type === 3) {
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