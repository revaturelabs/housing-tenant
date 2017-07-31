import { moveModule as mm } from './module';

var moveService = mm.factory('moveService', ['$http', function ($http) {
   return {
      getListRequest: function (scope, aptGuid, userguid) {
         $http.get('http://housingtenantbusiness.azurewebsites.net/api/request?=' + aptGuid).then(
            function (res) {
               console.log('this move reques')               
               console.log(res)
               scope.reqList = [];
               res.data.forEach(element => {
                  console.log(element);
                  if (element.type == "MoveRequest" && element.initiator.personId == userguid) {
                     console.log(element);
                     scope.reqList.push(element);
                  }
                  });
               console.log(scope.reqList);
            }, function (err) {
               console.log(err);
            }
         )
      },
      postRequest: function (request, scope) {
         $http({
            method: 'POST',
            url: 'http://housingtenantbusiness.azurewebsites.net/api/request/moverequest/',
            withCredentials: true,
            headers: {
               'Access-Control-Allow-Origin': '*',
               'Content-Type': 'application/json',
               'Access-Control-Allow-Credentials': 'true',
               'Access-Control-Allow-Methods': 'POST'
            },
            data: JSON.stringify(request)
         }).then(function (res) {
            scope.reqList.push(request);
            console.log(res);
         }, function (err) {
            console.log(err);
         });
      }
   }
}])