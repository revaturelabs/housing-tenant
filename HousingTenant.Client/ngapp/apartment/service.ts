import {apartmentModule as am} from './module';

var appartmentService = am.factory('aptFactory', ['$htpp', function($http){
   return{
      getApartment : function(scope,address){
         $http.get('http://localhost:5000/api/values/', {params: address}).then(
            function(res){
               console.log(res);
               scope.apartment;
            },function(err){
               console.log(err);
            }
         );
      }
   };
}]);