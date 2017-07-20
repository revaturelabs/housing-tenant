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

h.controller('homeController', ['$scope', 'homeFactory', function ($scope, homeFactory) {
  $scope.myAddress = new Address();
  $scope.entities = [
    new Entity('Address', 'Address')
  ];

  $scope.processRequest = function (id) {
    homeFactory.getAddress(id, $scope.myAddress);
  }
  $scope.openMenu = function () {
    document.getElementById("mySidenav").style.width = "250px";
    document.getElementById("main").style.marginLeft = "250px";
  }
  $scope.closeMenu = function () {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("main").style.marginLeft = "0px";
  }

  $scope.displayPage = function (id){
    $scope.closeMenu();
    switch(id){
      case "supplies":
      homeFactory.getSuppliesPage();
      break;

      default:
      console.log("did nothing");
    }
  }
}]);
