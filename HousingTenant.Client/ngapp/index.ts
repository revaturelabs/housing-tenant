import * as ng from 'angular';
import 'angular-route';
import 'angular-material';

//importing CSS
import './css/index.css';
import './css/modal.css';
//importing TS
import './home/controller';
import './supplies/controllers';
//importing HTML
import 'file-loader?name=[name].[ext]&outputPath=html/!./html/footer.html';
import 'file-loader?name=[name].[ext]&outputPath=html/!./html/navbar.html';
import 'file-loader?name=[name].[ext]&outputPath=html/!./html/sidebar.html';
//Testing GITLAB


var ngHousingTenant = ng.module('ngHousingTenant', ['ngRoute', 'ngMaterial','ngHome', 'supplyModule']);

ngHousingTenant.config(['$routeProvider', function($routeProvider){
  $routeProvider
    .when('/',{
      controller: 'homeController',
      templateUrl: 'ngapp/home/partials/template.html'
    })
    .when('/supplies', {
      controller: 'suppliesCtrl',
      templateUrl: 'ngapp/supplies/partials/template.html'
    })
    .otherwise({
      redirectTo: '/'
    });
}]);