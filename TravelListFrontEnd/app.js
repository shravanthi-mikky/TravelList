var app=angular.module("TravelListApp",['ngRoute','ngStorage','ngTouch','ngAnimate','ui.bootstrap']);

 app.config(["$routeProvider",function($routeProvider){

$routeProvider.
 when("/Login",{
    templateUrl:"Components/Login/Login.html",
    controller:"loginCtrl"
}).
when("/Dashboard",{
    templateUrl:"Components/Dashboard/Dashboard.html",
    controller:"DashboardCtrl"
}).

when("/AddTravel",{
    templateUrl:"Components/AddTravel/AddTravel.html",
    controller:"DashboardCtrl"
}).

when("/UpdateEmploy",{
    templateUrl:"Components/UpdateEmploy/UpdateEmploy.html",
    controller:"DashboardCtrl"
}).

when("/Invoice",{
    templateUrl:"Components/Invoice/Invoice.html",
    controller:"InvoiceController"
}).

when("/pay",{
    templateUrl:"Components/Pay1/pay.html",
    controller:"InvoiceController"
}).

when("/Sample",{
    templateUrl:"Components/Payment/Sample.html",
    controller:"InvoiceController"
}).

otherwise({
    redirectTo:"/Login"
    });
}]); 