import { home as h } from './module';

function failure (err) {
  console.log(err);
}

h.factory('homeFactory', ['$http', function ($http) {
  return {
    getAddress: function (id: number, obj) {
      $http.get('http://localhost:53948/api/address/getaddress' /*+ id*/ + '/').then(function (res) {
        obj.getAddress(res);
      }, failure);
    }, 
    getSuppliesPage: function () {
      $http.get('ngapp/supplies/partials/template.html').then(function (res){
        document.getElementById("body").innerHTML = res.data;
      }, failure);
    },
  }
}]);
 