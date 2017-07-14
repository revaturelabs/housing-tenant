import * as ng from 'angular';
import 'angular-route';
import 'angular-material';
import './home/controller';

var ngHousingTenant = ng.module('ngHousingTenant', ['ngHome', 'ngRoute', 'ngMaterial'])

ngHousingTenant.config(['$routeProvider', function($routeProvider){
  $routeProvider
    .when('/',{
      controller: 'homeController',
      templateUrl: 'ts/home/template.html'
    })
    .otherwise({
      redirectTo: '/'
    });
}]);