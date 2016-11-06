angular.module('app.controllers', [])
  
.controller('menuCtrl', ['$scope', '$stateParams', // The following is the constructor function for this page's controller. See https://docs.angularjs.org/guide/controller
// You can include any angular dependencies as parameters for this function
// TIP: Access Route Parameters for your page via $stateParams.parameterName
function ($scope, $stateParams) {


}])
      
.controller('relatorioCtrl', ['$scope', '$stateParams', // The following is the constructor function for this page's controller. See https://docs.angularjs.org/guide/controller
// You can include any angular dependencies as parameters for this function
// TIP: Access Route Parameters for your page via $stateParams.parameterName
function ($scope, $stateParams) {
    var vm = $scope;
    vm.items =[{data:"01/11/2016", status:1, observacao: "Presente por período integral"},
                {data:"02/11/2016", status:2, observacao: "Aluno não compareceu na escola"},
                {data:"03/11/2016", status:3, observacao: "Aluno não estava presente na última aula"},
                {data:"04/11/2016", status:1, observacao: "Presente por período integral"}];
    vm.aluno = "Aluno Teste";

}])
   
.controller('filhosCtrl', ['$scope', '$stateParams', '$state', '$http', // The following is the constructor function for this page's controller. See https://docs.angularjs.org/guide/controller
// You can include any angular dependencies as parameters for this function
// TIP: Access Route Parameters for your page via $stateParams.parameterName
function ($scope, $stateParams, $state, $http) {
     var vm = $scope;
    // vm.filhos =[{nome:"João", id:1},
    //             {nome:"Maria", id:2},
    //             {nome:"José", id:3},
    //             {nome:"Madelena", id:4}];
    $http.get("http://educamt.azurewebsites.net/responsavel/1/filhos")     
    .success(function(data, status, headers,config){
      console.log('data success');
      console.log(data); // for browser console
      $scope.filhos = data; // for UI
    })
    .error(function(data, status, headers,config){
      console.log('data error');
    })
    .then(function(result){
      console.log('aqui');
      things = result.filhos      
    });      
}])
   
.controller('loginCtrl', ['$scope', '$stateParams', // The following is the constructor function for this page's controller. See https://docs.angularjs.org/guide/controller
// You can include any angular dependencies as parameters for this function
// TIP: Access Route Parameters for your page via $stateParams.parameterName
function ($scope, $stateParams) {
 
  
}])
 