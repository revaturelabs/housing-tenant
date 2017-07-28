import { home as h } from './module';
import './service';
import '../apartment/service';
//import 'adal-angular/lib/adal-angular';



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
  
  getPerson(res: any, address: Address){
    this.FirstName = res.data.firstName;
    this.LastName = res.data.lastName;
    var address2 = new Address();
    address2.getAddress(res.data.address);
    this.Address = address2;
  }
}

var myController = h.controller('homeController', ['$scope', 'homeFactory', 'aptFactory', '$http', 'adalAuthenticationService', function ($scope, homeFactory, aptFactory, $http, adalAuthenticationService) {

  $scope.signIn = function () {
        adalAuthenticationService.login();
    };

    $scope.signOut = function () {
        adalAuthenticationService.logOut();
    };
  
  var email = adalAuthenticationService.userInfo.userName;
  
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

  $scope.processPerson = function(email: string){
    homeFactory.getPerson(email, $scope.myPerson, $scope.myAddress);
  }

  $scope.init = function(){
    if(email != "")
      $scope.processPerson(email);
  }

  //aptFactory.getApartment($scope, $scope.myAddress);

}]);
