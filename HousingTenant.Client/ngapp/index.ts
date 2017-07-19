import * as ng from 'angular';
import 'angular-route';
import 'angular-material';

import './home/controller';
import './supplies/controllers';

var ngHousingTenant = ng.module('ngHousingTenant', ['ngRoute', 'ngMaterial','ngHome', 'supplyModule' ])

ngHousingTenant.config(['$routeProvider', function($routeProvider){
  $routeProvider
    .when('/',{
      controller: 'homeController',
      templateUrl: 'ts/home/partials/template.html'
    })
    .when('/supplies', {
      controller: 'suppliesCtrl',
      templateUrl: 'ts/supplies/partials/template.html'
    })
    .otherwise({
      redirectTo: '/'
    });
}]);