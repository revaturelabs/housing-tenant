var fn = require('../jsbin/index.new.js');

//This is the Test Class or [TestFixture]
describe('First Test', function(){
   //this is the Test Method or [Test]
   it('should add two numbers', function(){
      //this is the Assertion
      expect(fn.addNumbers(1,3)).toEqual(4);
   });
});