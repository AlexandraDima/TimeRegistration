
var app = angular.module("LikesModule", []);

app.controller("LikesController", function ($scope) {
    var projects = [
        { name: "Umbraco", likes: 0, dislikes: 0 },
        { name: "Drupal", likes: 0, dislikes: 0 },
        { name: "SharePoint", likes: 0, dislikes: 0 },
    ];

    $scope.projects = projects;

    $scope.incrementLikes = function (project) {
        project.likes++;
    };

    $scope.incrementDislikes = function (project) {
        project.dislikes++;
    }
});