"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ng = require("angular");
require("angular-route");
require("angular-material");
require("./home/controller");
require("./supplies/controllers");
var ngHousingTenant = ng.module('ngHousingTenant', ['ngRoute', 'ngMaterial', 'ngHome', 'supplyModule']);
ngHousingTenant.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/', {
            controller: 'homeController',
            templateUrl: 'ts/home/template.html'
        })
            .when('/supplies', {
            controller: 'suppliesCtrl',
            templateUrl: 'ts/supplies/partials/template.html'
        })
            .otherwise({
            redirectTo: '/'
        });
    }]);
