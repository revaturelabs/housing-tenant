"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var module_1 = require("./module");
function failure(err) {
    console.log(err);
}
module_1.home.factory('homeFactory', ['$http', function ($http) {
        return {
            getAddress: function (id, obj) {
                $http.get('http://localhost:53948/api/address/getaddress' /*+ id*/ + '/').then(function (res) {
                    obj.getAddress(res);
                }, failure);
            }
        };
    }]);
