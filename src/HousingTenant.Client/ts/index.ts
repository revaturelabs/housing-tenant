import * as ng from 'angular';
import 'angular-route';

ng.module('buttonsDemo1', ['ngMaterial'])

.controller('AddressButtonCtrl', function($scope) {
  $scope.title1 = 'Button';
  $scope.title4 = 'Warn';
  $scope.isDisabled = true;

  $scope.googleUrl = 'http://google.com';

});