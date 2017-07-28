import { home as h } from './module';

function failure (err) {
  console.log(err);
}

h.factory('homeFactory', ['$http', function ($http) {
  return {
    getAddress: function (id: number, obj) {
      $http.get('http://housingtenantbusiness.azurewebsites.net/api/address/' /*+ id*/ + '/').then(function (res) {
        obj.getAddress(res);
      }, failure);
    }, 
    getPerson: function (email: string, person, address) {
      $http.get('http://housingtenantbusiness.azurewebsites.net/api/person/email?=' + email).then(function (res) {
        person.getPerson(res, email, address);
      }, failure);
    }, 
    getSuppliesPage: function () {
      $http.get('ngapp/supplies/partials/template.html').then(function (res){
        document.getElementById("body").innerHTML = res.data;
      }, failure);
    },
  }
}]);
 