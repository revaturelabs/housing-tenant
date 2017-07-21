import * as ng from 'angular';
import 'angular-route';
import 'angular-material';

//importing CSS
import './css/index.css';
import './css/modal.css';
//importing TS
import './home/controller';
import './supplies/controllers';
import './apartment/controller';
import './maintenance/controller';
//importing HTML
import 'file-loader?name=[name].[ext]&outputPath=html/!./html/footer.html';
import 'file-loader?name=[name].[ext]&outputPath=html/!./html/navbar.html';
import 'file-loader?name=[name].[ext]&outputPath=html/!./html/sidebar.html';
//Testing GITLAB


var ngHousingTenant = ng.module('ngHousingTenant', ['ngRoute', 'ngMaterial','ngHome', 'supplyModule', 'aptModule', 'maintenanceModule']);

ngHousingTenant.config(['$routeProvider', function($routeProvider){
  $routeProvider
    .when('/apartment', {
      controller: 'aptCtrl',
      templateUrl: 'ngapp/apartment/partials/template.html'
    })
    .when('/home',{
      controller: 'homeController',
      templateUrl: 'ngapp/home/partials/template.html'
    })
    .when('/supplies', {
      controller: 'suppliesCtrl',
      templateUrl: 'ngapp/supplies/partials/template.html'
    })
    .when('/maintenance', {
      controller: 'maintenanceCtrl',
      templateUrl: 'ngapp/maintenance/partials/template.html'
    })
    .otherwise({
      redirectTo: '/'
    });
}]);