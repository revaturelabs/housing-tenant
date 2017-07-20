var fn = require ('../jsbin/home/module.js');
//var fn = require('../jsbin/index.js')
var fn = require ('../jsbin/home/controller.js');
var ng = require('angular-mocks');
//var

describe('the home constroller', function(){
   var controller, httpbackend, scope = {};
   //pull up module called 'home'
   beforeEach(angular.mock.module('ngHome'));
   //mock a controller
   beforeEach(inject(function(_$controller_, _$httpBackend_){
      //look for this controller and take its scope
      controller = _$controller_('homeController', {$scope: scope})
      httpbackend =  _$httpBackend_;
   }));
 
   it('should have something', function(){
      expect(scope.something).toEqual('hello mock');
   });

   it('should sum 2 numbers', function(){
      expect(scope.addNumbers(1,2)).toEqual(3);
   });
   it('should do ajax', function(){
      httpbackend.expectGET('./someurl').respond('boyahh!');
      scope.seeYouLater();
      httpbackend.flush();
      expect(scope.success.data).toBe('boyahh!');
   })

})