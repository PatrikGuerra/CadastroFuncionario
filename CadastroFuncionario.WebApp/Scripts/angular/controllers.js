var CadFuncControllers = angular.module("CadFuncControllers", []);

CadFuncControllers.controller("ListController", ['$scope', '$http',
    function ($scope, $http) {
        $http.get("/api/funcionarios").then(function (response) {
            console.log(response.data)
            $scope.employees = response.data;
        }, function error(response) {
            console.log(response)
        });
    }
]);

CadFuncControllers.controller("DeleteController", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {
        $scope.id = $routeParams.id;
        $http.get('/api/funcionarios/' + $routeParams.id).then(function (response) {
            $scope.funcionario = response.data
        }, function error(response) {
            console.log(response)
        });

        $scope.delete = function () {
            $http.delete('/api/funcionarios/' + $scope.id).then(function (response) {
                if (!response.data.Success) {
                    console.log(response)
                    $scope.error = response.data;
                } else {
                    $location.path('/list');
                }
            }, function error(response) {
                $scope.error = "An error has occured while deleting employee! " + response.data;
            });
        };
    }
]);

CadFuncControllers.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {
        $scope.save = function () {
            var funcionario = $scope.funcionario;
            $scope.error = null;

            if ($routeParams.id) {
                $http.put('/api/funcionarios/' + funcionario.Id, funcionario).then(function (response) {
                    if (!response.data.Success) {
                        console.log(response)
                        $scope.error = response.data;
                    } else {
                        $location.path('/list');
                    }
                }, function error(response) {
                    console.log(response)
                    $scope.error = "An Error has occured while Saving customer! " + response.data.ExceptionMessage;
                });
            } else {
                $http.post('/api/funcionarios', funcionario).then(function (response) {
                    if (!response.data.Success) {
                        console.log(response)
                        $scope.error = response.data;
                    } else {
                        $location.path('/list');
                    }
                }, function error(response) {
                    console.log(response)
                    $scope.error = "An error has occured while adding employee! " + response.data.ExceptionMessage;
                });
            }
        }

        if ($routeParams.id) {
            console.log($routeParams.id)
            $scope.title = "Editar Funcionário";

            $http.get('/api/funcionarios/' + $routeParams.id).then(function (response) {
                $scope.funcionario = response.data;
            }, function error(response) {
                console.log(response)
            });
        } else {
            $scope.title = "Cadastrar Funcionário";
        }
    }
]);