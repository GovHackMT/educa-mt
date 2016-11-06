angular.module('app.controllers', [])
  
.controller('menuCtrl', ['$scope', '$stateParams', // The following is the constructor function for this page's controller. See https://docs.angularjs.org/guide/controller
// You can include any angular dependencies as parameters for this function
// TIP: Access Route Parameters for your page via $stateParams.parameterName
function ($scope, $stateParams) {


}])
      
.controller('relatorioCtrl', ['$scope', '$stateParams', '$http', // The following is the constructor function for this page's controller. See https://docs.angularjs.org/guide/controller
// You can include any angular dependencies as parameters for this function
// TIP: Access Route Parameters for your page via $stateParams.parameterName
function ($scope, $stateParams, $http) {
    var vm = $scope;
    $http.get("http://educamt.azurewebsites.net/responsavel/aluno/"+$stateParams.filho)     
    .success(function(data, status, headers,config){
      $scope.aluno = data.nome; // for UI
    })
    .error(function(data, status, headers,config){
      console.log('data error');
    })
    .then(function(result){
      things = result.aluno      
    });
    
    $http.get("http://educamt.azurewebsites.net/responsavel/"+$stateParams.responsavelId+"/filho/"+$stateParams.filho+"/relatorio")     
    .success(function(data, status, headers,config){
      $scope.items = data; // for UI
    })
    .error(function(data, status, headers,config){
      console.log('data error');
    })
    .then(function(result){
      things = result.items      
    });        
}])
   
.controller('filhosCtrl', ['$scope', '$stateParams', '$state', '$http', // The following is the constructor function for this page's controller. See https://docs.angularjs.org/guide/controller
// You can include any angular dependencies as parameters for this function
// TIP: Access Route Parameters for your page via $stateParams.parameterName
function ($scope, $stateParams, $state, $http) {
    $scope.responsavelId = $stateParams.responsavelId;
    $http.get("http://educamt.azurewebsites.net/responsavel/"+ $stateParams.responsavelId +"/filhos")     
    .success(function(data, status, headers,config){
      $scope.filhos = data; // for UI
    })
    .error(function(data, status, headers,config){
      console.log('data error');
    })
    .then(function(result){
      things = result.filhos      
    });      
}])
   
.controller('loginCtrl', ['$scope', '$stateParams', // The following is the constructor function for this page's controller. See https://docs.angularjs.org/guide/controller
// You can include any angular dependencies as parameters for this function
// TIP: Access Route Parameters for your page via $stateParams.parameterName
function ($scope, $stateParams) {
 
  
}])
 