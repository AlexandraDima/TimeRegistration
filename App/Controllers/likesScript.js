
var app = angular.module("LikesModule", []);

app.controller("DislikesController", function ($scope) {
    var projects = [
        { name: "Umbraco", likes: 0, dislikes: 0 },
        { name: "Drupal", likes: 0, dislikes: 0 },
        { name: "SharePoint", likes: 0, dislikes: 0 },
    ];

    $scope.projects = projects;
    $scope.count = 0;
    $scope.myFunc = function () {
        $scope.count++;
        console.log("count");
    };

    $scope.incrementLikes = function (project) {
        project.likes++;
    };

    $scope.incrementDislikes = function (project) {
        project.dislikes++;
    }
});

app.controller("EmployeesController", function ($scope) {
    var themes = [
        {
            name: "Umbraco",
            employees: [
                { name: "Maria", gender: 1  },
                { name: "Joan", gender: 2}
            ]
        },
        {
            name: "Drupal",
            employees: [
                { name: "George", gender: 1 },
                { name: "John", gender: 2 }
            ]
        }

    ];
    
    $scope.themes = themes;
});
