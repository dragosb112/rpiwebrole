
// var mainController = function($scope){

//     $scope.message = "WebAPI RaspPi Init";

// };

(function(){ 

    var app = angular.module('myApp', []);


    var mainCtrl = function($scope){

        $scope.message = "MainCtrl initialisation";

    };

     app.controller('mainCtrl', mainCtrl); 

}());
