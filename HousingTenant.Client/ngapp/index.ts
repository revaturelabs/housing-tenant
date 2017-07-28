import * as ng from 'angular';
import 'angular-route';
import 'angular-material';
import 'adal-angular/lib/adal-angular'

//importing CSS
import './css/index.css';
import './css/modal.css';
//importing TS
import './home/controller';
import './supplies/controllers';
import './apartment/controller';
import './maintenance/controller';
import './complaints/controller';
import './move/controller'

//importing HTML
import 'file-loader?name=[name].[ext]&outputPath=html/!./html/footer.html';
import 'file-loader?name=[name].[ext]&outputPath=html/!./html/navbar.html';
import 'file-loader?name=[name].[ext]&outputPath=html/!./html/sidebar.html';
//Testing GITLAB
//Testing Bundle

var ngHousingTenant = ng.module('ngHousingTenant', ['AdalAngular', 'ngRoute', 'ngMaterial', 'ngHome', 'supplyModule', 'aptModule', 'maintenanceModule', 'complaintModule', 'moveModule']);

ngHousingTenant.config(['$routeProvider', '$locationProvider', '$httpProvider', 'adalAuthenticationServiceProvider', function ($routeProvider, $locationProvider, $httpProvider, adalProvider) {
  $routeProvider
    .when('/apartment', {
      controller: 'aptCtrl',
      templateUrl: 'ngapp/apartment/partials/template.html',
      requireADLogin: true
    })
    .when('/home', {
      controller: 'homeController',
      templateUrl: 'ngapp/home/partials/template.html'
    })
    .when('/supplies/:aptguid', {
      controller: 'suppliesCtrl',
      templateUrl: 'ngapp/supplies/partials/template.html'
    })
    .when('/maintenance/:aptguid', {
      controller: 'maintenanceCtrl',
      templateUrl: 'ngapp/maintenance/partials/template.html'
    })
    .when('/complaints/:aptguid', {
      controller: 'complaintCtrl',
      templateUrl: 'ngapp/complaints/partials/template.html'
    })
    .when('/move/:aptguid', {
      controller: 'moveCtrl',
      templateUrl: 'ngapp/move/partials/template.html'
    })
    .otherwise({
      redirectTo: '/home'
    });
  $locationProvider.html5Mode(true).hashPrefix('!');

  adalProvider.init({
    tenant: 'fredbelotterevature.onmicrosoft.com',
    clientId: 'b30b8a78-6e98-4bac-afac-3989d56b3551',
    //cacheLocation: 'localStorage'
  }, $httpProvider);
}]);