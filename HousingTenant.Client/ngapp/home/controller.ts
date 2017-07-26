import { home as h } from './module';
import './service';
import '../apartment/service';



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
    this.Address1 = res.address1;
    this.Address2 = res.address2;
    this.City = res.city;
    this.State = res.state;
    this.Zip = res.zipCode;
  }
}

class Person {
  FirstName: string;
  LastName: string;
  Address: Address;

  constructor(){
    this.FirstName = 'John';
    this.LastName = 'Doe';
  }
  
  getPerson(res: any, id: number, address: Address){
    this.FirstName = res.data[id].firstName;
    this.LastName = res.data[id].lastName;
    address.getAddress(res.data[id].address);
    this.Address = address;
  }
}

var myController = h.controller('homeController', ['$scope', 'homeFactory', 'aptFactory', '$http', function ($scope, homeFactory, aptFactory, $http) {

  $scope.myAddress = new Address();
  
  $scope.myPerson = new Person();

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

  $scope.processPerson = function(id){
    homeFactory.getPerson(id, $scope.myPerson, $scope.myAddress);
  }

  $scope.init = function(){
    $scope.processPerson(1);
  }

  aptFactory.getApartment($scope, $scope.myAddress);
  
}]);
