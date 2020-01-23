
var app = angular.module('projectsModule', []);

app.controller('nameController', ['$scope', function ($scope) {
    $scope.name = "Alexandra";

    $scope.count = 0;
    $scope.myFunc = function () {
        $scope.count++;
        console.log("count");
    };

}]);

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


        $scope.sortColumn = "ProjectName";

        //descending sort will be false
        $scope.reverseSort = false;

        //function to assign the ascending or descending order based on the column value
        $scope.sortData = function (column) {
            $scope.reverseSort = ($scope.sortColumn == column) ? !$scope.reverseSort : false;
            $scope.sortColumn = column;
        }

        //function to assign css classes based on the column value
        $scope.getSortClass = function (column) {
            if ($scope.sortColumn == column) {
                return $scope.reverseSort ? 'arrow-down' : 'arrow-up';
            }
            return '';
        }
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