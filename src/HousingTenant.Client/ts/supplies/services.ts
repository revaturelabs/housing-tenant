import {supplyModule as sm} from './module';


// var config = {
//     params: {
//         one: ,
//         two: 
//     }
// }

var supplyService = sm.factory('supplyRequestListSvc', ['$http', function($http){
   return {
      getRequestList: function(address, requestList){
         console.log(address);
         $http.get('http://localhost:5000/api/values/', { params: address } ).then(
            function(res){
               console.log(res.data); 
               return res.data;
            }, function(err){
               console.log(err);
            });
      }
   }
}]);