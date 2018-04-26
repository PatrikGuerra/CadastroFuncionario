var CadFuncApp = angular.module('CadFuncApp', ['ngRoute', 'CadFuncControllers']);

CadFuncApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/list', {
        templateUrl: 'Funcionario/lista.html',
        controller: 'ListController'
    }).
    when('/create', {
        templateUrl: 'Funcionario/editar.html',
        controller: 'EditController'
    }).
    when('/edit/:id', {
        templateUrl: 'Funcionario/editar.html',
        controller: 'EditController'
    }).
    when('/delete/:id', {
        templateUrl: 'Funcionario/deletar.html',
        controller: 'DeleteController'
    }).
    otherwise({
        redirectTo: '/list'
    });
}]);