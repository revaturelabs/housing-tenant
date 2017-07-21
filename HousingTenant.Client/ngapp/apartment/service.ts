import {apartmentModule as am} from './module';

var appartmentService = am.factory('aptFactory', ['$http', function($http){
   return{
      getApartment : function(scope,address){
         $http.get('http://localhost:5000/api/values/', {params: address}).then(
            function(res){
               console.log(res);
               scope.apartment = res.data;
            },function(err){
               console.log(err);
               scope.apartment = {};
               scope.apartment.address = address;
               scope.apartment.beds = 3;
               scope.apartment.bathrooms = 2;
               scope.apartment.complexname = 'Westerly At Worldgate';
               scope.apartment.people = [
                  {
                     firstname: 'Julian',
                     lastname: 'Rojas'
                  },
                  {
                     firstname: 'Jameson',
                     lastname: 'Bruuuhhh'
                  }
               ];
               console.log(scope.apartment);
            }
         );
      }
   };
}]);