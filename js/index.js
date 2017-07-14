"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ng = require("angular");
require("angular-route");
require("angular-material");
require("./home/controller");
var ngHousingTenant = ng.module('ngHousingTenant', ['ngHome', 'ngRoute', 'ngMaterial']);
ngHousingTenant.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/', {
            controller: 'homeController',
            templateUrl: 'ts/home/template.html'
        })
            .otherwise({
            redirectTo: '/'
        });
    }]);
