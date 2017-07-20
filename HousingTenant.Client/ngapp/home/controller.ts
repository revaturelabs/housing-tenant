import { home as h } from './module';
import './service';

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
    this.Address1 = res.data.Address1;
    this.Address2 = res.data.Address2;
    this.City = res.data.City;
    this.State = res.data.State;
    this.Zip = res.data.Zip;
  }
}

var myController = h.controller('homeController', ['$scope', 'homeFactory', '$http', function ($scope, homeFactory, $http) {
  $scope.myAddress = new Address();
  $scope.entities = [
    new Entity('Address', 'Address')
  ];

  $scope.something = 'hello mock';
  $scope.addNumbers = function(n1,n2){
    return n1+n2;
  }

  $scope.seeYouLater = function(){
    $http.get('./someurl').then(function(res){
      $scope.success = res;
    });
  };

  $scope.processRequest = function (id) {
    homeFactory.getAddress(id, $scope.myAddress);
  }
  
}]);
