
var app = angular.module('projectControllerModule', []);

app.controller('Name', function ($scope) {
    $scope.name = "Alexandra";


});

//Simple GET request
/*
app.controller('projectController', ['$scope', '$http', function ($scope, $http) {
    $http.get('/Home/listProjects').then(function (response) {
        $scope.projects = response.data;
    })
}]);
*/
//Get request with an object as an argument

app.controller('projectController', ['$scope', '$http', function ($scope, $http) {
    $http({
        method: "GET",
        //Url (ControllerName/ActionName)
        url: "/Home/listProjects"
    }).then(function mySuccess(response) {
        $scope.projects = response.data;
    }, function myError(response) {
        $scope.projects = response.statusText;
    });
}]);
/*
app.controller('addProjectController', ['$scope', '$http', function ($scope, $http) {
    $http.post('/Home/Create').then(function (response) {
        $scope.projects = response.data;
    })
}]);
*/

