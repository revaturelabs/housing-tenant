import { home as h } from './module';

var pObj;
var sObj;

function success (res) {
  //this.a = 'banana';
 //pObj.name = res.data.name;
  //console.log(obj1);
  //console.log(res);
  //console.log(tempObj);
  //console.log(res.data);
  // (function () {});
  // fn.apply() || fn.call();

  if (pObj) {
    pObj.name = res.data.name;
  }

  if (sObj) {
    sObj.name = res.data.name;
  }
}

function failure (err) {
  console.log(err);
}

// var obj1 = {
//   b: 'hello'
// };

h.factory('homeFactory', ['$http', function ($http) {
  return {
    getAddress: function (id: number, obj) {
      $http.get('http://localhost:53948/api/address/getaddress' /*+ id*/ + '/').then(function (res) {
        obj.getAddress(res);
      }, failure);
    }
  }
}]);
