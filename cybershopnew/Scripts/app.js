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
            .when("/Cart",
            {
                templateUrl: "Templates/Cart.html",
                controller: "cartController"
            })

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

            .when("/Checkout",
            {
                templateUrl: "Templates/Checkout.html",
                controller: "cartController"
            })

            .when("/CustomerDetails",
            {
                templateUrl: "Templates/CustomerDetails.html"
            })




        
                   
    }]);

myApp.controller("booksController", function ($scope,$http) {
    
    $http.get("api/bookstables/Getbookstables").
        then(function (response) {
            $scope.books = response.data;
        });



    $scope.addtocart = function (index) {
        $scope.chosen = "";
        $scope.amount = "";
        $scope.chosen = $scope.books[index]
        console.log($scope.chosen);

        var detailsofbooks = {
            'Name': $scope.chosen.Name,
            'Price': $scope.chosen.Price,
            'Id': $scope.chosen.Id
        };

        console.log(detailsofbooks);

        $http.post("api/Carts/PostCart", detailsofbooks);

    }
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

    $scope.addtocart = function (index) {
        $scope.chosen = "";
        $scope.amount = "";
        $scope.chosen = $scope.mobiles[index]
        console.log($scope.chosen);

        var detailsofmobiles = {
            'Name': $scope.chosen.Name,
            'Price': $scope.chosen.Price,
            'Id': $scope.chosen.Id
        };

        console.log(detailsofmobiles);

        $http.post("api/Carts/PostCart", detailsofmobiles);

    }
        
});

myApp.controller("accessoryController", function ($scope, $http) {

    $http.get("api/accessories/Getaccessories").
        then(function (response) {
            $scope.accessories = response.data;
            console.log($scope.accessories);

        });

    $scope.addtocart = function (index) {
        $scope.chosen = "";
        $scope.amount = "";
        $scope.chosen = $scope.accessories[index]
        console.log($scope.chosen);
                       
        var detailsofaccessories = {
            'Name': $scope.chosen.Name,
            'Price': $scope.chosen.Price,
            'Id':$scope.chosen.Id
        };

        console.log(detailsofaccessories);

        $http.post("api/Carts/PostCart", detailsofaccessories);
                
        }
       
    });

    myApp.controller("clothingController", function ($scope, $http) {

        $http.get("api/clothingtables/Getclothingtables").
            then(function (response) {
                $scope.clothes = response.data;
                
            });

        $scope.addtocart = function (index) {
            $scope.chosen = "";
            $scope.amount = "";
            $scope.chosen = $scope.clothes[index]
            console.log($scope.chosen);

            var detailsofclothes = {
                'Name': $scope.chosen.Name,
                'Price': $scope.chosen.Price,
                'Id': $scope.chosen.Id
            };

            console.log(detailsofclothes);

            $http.post("api/Carts/PostCart", detailsofclothes);
            //$scope.successfullyadded = "ADDED TO YOUR CART";

        }
                   
}); 


myApp.controller("cartController", function ($scope, $http) {

    $http.get("api/Carts/GetCarts").
        then(function (response) {
            $scope.cart = response.data;
            console.log($scope.cart);
                        
        });

    $scope.removefromcart = function (index) {

        $scope.chosentoremove = $scope.cart[index]
        var producttoberemoved = $scope.chosentoremove.Id;
        console.log(producttoberemoved);
        $http.delete("api/Carts/DeleteFromCart/" + producttoberemoved).
            then(function successCallBack(response) {
                $scope.msg = "removed";
                $http.get("api/Carts/GetCarts").
                    then(function (response) {
                        $scope.cart = response.data;
                        console.log($scope.cart);

                    });

                
                //console.log($scope.msg);
                console.log(response.data);
            }), function errorCallBack(errorResponse) {
                console.log(errorResponse.data);
            };
    }

    $http.get("api/Carts/CalculateSum").
        then(function (response) {
            $scope.total = response.data;
            console.log($scope.total);
        });
    
        
});