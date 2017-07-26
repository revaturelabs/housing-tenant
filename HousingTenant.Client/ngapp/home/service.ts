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
    getPerson: function (id: number, person, address) {
      $http.get('http://housingtenantbusiness.azurewebsites.net/api/person' /*+ id*/ + '/').then(function (res) {
        console.log(res);
        console.log(res.data[id].firstName);
        person.getPerson(res, id, address);
      }, failure);
    }, 
    getSuppliesPage: function () {
      $http.get('ngapp/supplies/partials/template.html').then(function (res){
        document.getElementById("body").innerHTML = res.data;
      }, failure);
    },
  }
}]);
 