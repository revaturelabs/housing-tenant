import { home as h } from './module';
import './service';
import '../apartment/service';

class Person {
  FirstName: string;
  LastName: string;

  constructor(){
    this.FirstName = 'John';
    this.LastName = 'Doe';
  }
  
  getPerson(res: any, id: number){
    this.FirstName = res.data[id].firstName;
    this.LastName = res.data[id].lastName;
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

  

var myController = h.controller('homeController', ['$scope', 'homeFactory', 'aptFactory', '$http', function ($scope, homeFactory, aptFactory, $http) {

  $scope.myAddress = {
   Address1: "2100 Wilkes Court",
   Address2: "",
   ApartmentNumber: "102",
   City: "Herndon",
   State: "Virgina",
   ZipCode: "20105"
  };
  
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
    homeFactory.getPerson(id, $scope.myPerson);
  }

  $scope.init = function(){
    $scope.processPerson(0);
  }

  aptFactory.getApartment($scope, $scope.myAddress);
  
}]);
