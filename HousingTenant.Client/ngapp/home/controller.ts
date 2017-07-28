import { home as h } from './module';
import './service';
import '../apartment/service';
//import 'adal-angular/lib/adal-angular';



class Address {
  address1: string;
  address2: string;
  city: string;
  state: string;
  zipCode: number;

  constructor() {
    this.address1 = 'NotAvailable';
    this.address2 = 'NotAvailable';
    this.city = 'NotAvailable';
    this.state = 'NotAvailable';
    this.zipCode = 0;
  }

  getAddress(res: any){
    this.address1 = res.address1;
    this.address2 = res.address2;
    this.city = res.city;
    this.state = res.state;
    this.zipCode = res.zipCode;
  }
}

class Person {
  firstName: string;
  lastName: string;
  address: Address;
  aptGuid: string;

  constructor(){
    this.firstName= 'Fred';
    this.lastName = 'Bel';
  }
  
  getPerson(res: any, address: Address){
    this.firstName = res.data.firstName;
    this.lastName = res.data.lastName;
    this.aptGuid = res.data.apartmentId;
    var address2 = new Address();
    address2.getAddress(res.data.address);
    this.address = address2;
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
    console.log('entering processRequest');    
    homeFactory.getAddress(id, $scope.myAddress);
  }

  $scope.processPerson = function(email: string){
    console.log('entering processPerson');
    homeFactory.getPerson(email, $scope.myPerson, $scope.myAddress);
    
  }

  $scope.init = function(){
    console.log('entering init');    
    if(email != "")
      $scope.processPerson(email);
  }

}]);
