"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var module_1 = require("./module");
require("./service");
// h.controller('AppCtrl', function($scope) {
//   $scope.title1 = 'Button';
//   $scope.title4 = 'Warn';
//   $scope.isDisabled = true;
//   $scope.googleUrl = 'http://google.com';
// });
var Entity = (function () {
    function Entity(t, v) {
        this.text = t;
        this.value = v;
    }
    return Entity;
}());
var Address = (function () {
    function Address() {
        this.Address1 = 'NotAvailable';
        this.Address2 = 'NotAvailable';
        this.City = 'NotAvailable';
        this.State = 'NotAvailable';
        this.Zip = 0;
    }
    Address.prototype.getAddress = function (res) {
        this.Address1 = res.data.address1;
        this.Address2 = res.data.address2;
        this.City = res.data.city;
        this.State = res.data.state;
        this.Zip = res.data.zip;
    };
    return Address;
}());
module_1.home.controller('homeController', ['$scope', 'homeFactory', function ($scope, homeFactory) {
        $scope.myAddress = new Address();
        $scope.entities = [
            new Entity('Address', 'Address')
        ];
        $scope.processRequest = function (id) {
            homeFactory.getAddress(id, $scope.myAddress);
            // var p = new Promise();
            // p.resolve(function (pass, fail) {
            //   if (true) {
            //     pass();
            //   } else {
            //     fail();
            //   }
            // });
        };
    }]);
