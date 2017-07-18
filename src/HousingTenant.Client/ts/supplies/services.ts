import {supplyModule as sm} from './module';

var supplyService = sm.factory('supplyRequestListSvc', ['$http', function($http){
   return {
      getRequestList: function(address, requestList){
         $http.get("http://localhost/tenant/" + address).then(
            function(res){
               requestList = res.data;
            }, function(err){
               console.log(err);
            });
      }
   }
}]);