"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var module_1 = require("./module");
var Request = (function () {
    function Request(n) {
        this.Name = n;
        this.Soap = true;
        this.ToiletPaper = false;
        this.PaperTowels = false;
        this.DishSoap = true;
        this.TrashBags = false;
        this.DishwasherDetergent = false;
        this.Sponges = false;
    }
    return Request;
}());
var supplyController = module_1.supplyModule.controller('suppliesCtrl', ['$scope', function ($scope) {
        $scope.requestList = [
            new Request('First Request'), new Request('Second Request'), new Request('Third Request')
        ];
    }]);
