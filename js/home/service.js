"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var module_1 = require("./module");
var pObj;
var sObj;
function success(res) {
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
function failure(err) {
    console.log(err);
}
var obj1 = {
    b: 'hello'
};
module_1.home.factory('homeFactory', ['$http', function ($http) {
        return {
            getAddress: function (id, obj) {
                $http.get('http://localhost:53948/api/address/getaddress' /*+ id*/ + '/').then(function (res) {
                    obj.getAddress(res);
                }, failure);
            }
        };
    }]);
