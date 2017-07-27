import {moveModule as mm} from './module';
import './service';
import '../apartment/service';

var moveController = mm.controller('moveCtrl', ['$scope', 'aptFactory', 'moveService', function($scope, aptFactory, moveService){
   aptFactory.getListApartments($scope);
}])