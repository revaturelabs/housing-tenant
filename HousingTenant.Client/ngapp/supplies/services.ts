import {supplyModule as sm} from './module';

var supplyService = sm.factory('supplyRequestListSvc', ['$http', function($http){
   return {
      getRequestList: function(aptidstring, scope){
         $http.get('http://localhost:5000/api/request/', { params: aptidstring } ).then(
            function(res){
               console.log(res.data); 
                  scope.reqList = res.data;
                  console.log(scope.reqList);
            }, function(err){
               console.log(err);
            });
      },
      postRequest: function(request){
            console.log(request);
            $http({
                  method: 'POST',
                  url: 'http://localhost:5000/api/request/',
                  withCredentials: true,
                  headers: {
                        'Access-Control-Allow-Origin': 'http://localhost:5000',
                        'Content-Type': 'application/json',
                        'Access-Control-Allow-Credentials' : 'true',
                        'Access-Control-Allow-Methods' : 'GET,PUT,POST,DELETE'
                  },
                  data: {request}
            }).then(function(res){
                  console.log(res);
            }, function(err){
                  console.log(err);
            });
      }
   };
}]);