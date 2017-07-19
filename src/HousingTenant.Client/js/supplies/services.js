"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var module_1 = require("./module");
// var config = {
//     params: {
//         one: ,
//         two: 
//     }
// }
var supplyService = module_1.supplyModule.factory('supplyRequestListSvc', ['$http', function ($http) {
        return {
            getRequestList: function (address, requestList) {
                console.log(address);
                $http.get('http://localhost:5000/api/values/', { params: address }).then(function (res) {
                    console.log(res.data);
                    return res.data;
                }, function (err) {
                    console.log(err);
                });
            }
        };
    }]);
