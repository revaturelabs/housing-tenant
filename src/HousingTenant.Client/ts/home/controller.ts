import { home as h } from './module';
import './service';

// h.controller('AppCtrl', function($scope) {
//   $scope.title1 = 'Button';
//   $scope.title4 = 'Warn';
//   $scope.isDisabled = true;

//   $scope.googleUrl = 'http://google.com';

// });

class Entity {
  text: string;
  value: string;

  constructor(t: string, v: string) {
    this.text = t;
    this.value = v;
  }
}

class Address {
  Address1: string;
  Address2: string;
  City: string;
  State: string;
  Zip: number;

  constructor() {
    this.Address1 = 'NotAvailable';
    this.Address2 = 'NotAvailable';
    this.City = 'NotAvailable';
    this.State = 'NotAvailable';
    this.Zip = 0;
  }

  getAddress(res: any){
    this.Address1 = res.data.address1;
    this.Address2 = res.data.address2;
    this.City = res.data.city;
    this.State = res.data.state;
    this.Zip = res.data.zip;
  }
}

h.controller('homeController', ['$scope', 'homeFactory', function ($scope, homeFactory) {
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
  }
}]);
