var myApp = angular.module('myApp', ['ngRoute'])
    .config(["$routeProvider", function ($routeProvider) {
        $routeProvider
            .when("/Books",
            {
                templateUrl: "/Templates/Books.html",
                controller: "booksController"
                //HTMLTemplateElement: "/Templates/FirstPage.html";
            })
            .when("/Mobiles",
            {
                templateUrl: "Templates/Mobiles.html",
                controller: "mobilestablesController"
            })
            .when("/ContactUs",
            {
                templateUrl: "Templates/ContactUs.html"
            })

            .when("/Home",
            {
            templateUrl:"Templates/Home.html"
            }
        )

            .when("/Accesories",
            {
                templateUrl: "Templates/Accessories.html",
                controller: "accessoryController"
            })

            .when("/Clothing",
            {
                templateUrl: "Templates/Clothing.html",
                controller: "clothingController"
            })
        
                   
    }]);

myApp.controller("booksController", function ($scope,$http) {
    
    $http.get("api/bookstables/Getbookstables").
        then(function (response) {
            $scope.books = response.data;
        });
    });

myApp.controller("SecondController", function ($scope) {
    $scope.courses = ['C#', 'C++', 'angular js', 'asp.net'];
    console.log($scope.courses);
});

myApp.controller("mobilestablesController", function ($scope, $http) {

    $http.get("api/mobilestables/Getmobilestables").
        then(function (response) {
            $scope.mobiles = response.data;
        });
});

myApp.controller("accessoryController", function ($scope, $http) {

    $http.get("api/accessories/Getaccessories").
        then(function (response) {
            $scope.accessories = response.data;
            console.log($scope.accessories);
        });
});

    myApp.controller("clothingController", function ($scope, $http) {

        $http.get("api/clothingtables/Getclothingtables").
            then(function (response) {
                $scope.clothes = response.data;
                console.log($scope.accessories);
            });
                
}); 