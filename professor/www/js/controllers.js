angular.module('app.controllers', [])

.controller('disciplinasCtrl', ['$scope', '$state', '$stateParams', '$http',
// The following is the constructor function for this page's controller. See https://docs.angularjs.org/guide/controller
// You can include any angular dependencies as parameters for this function
// TIP: Access Route Parameters for your page via $stateParams.parameterName
function ($scope, $state, $stateParams, $http) {

  var vm = $scope;

  vm.idProfessor = $stateParams.escola; //getting barVal
  // console.log($stateParams);
  console.log(vm.idProfessor);


  $http.get("http://educamt.azurewebsites.net/professor/" + vm.idProfessor + "/disciplinas")
    .success(function(data, status, headers,config){
      vm.disciplinas = data; // for UI
    })
    .error(function(data, status, headers,config){
      console.log('data error');
    })
    .then(function(result){
      things = result;
    });


  /*vm.disciplinas = [
    {id: 1, turma: '8 Série', horario:'7:30', periodo: 'Matutino', descricao: 'Matemática'},
    {id: 2, turma: '6 Série', horario:'8:30', periodo: 'Matutino', descricao: 'Matemática'},
    {id: 3, turma: '5 Série', horario:'14:00', periodo: 'Vespertino', descricao: 'Matemática'},
    {id: 4, turma: '8 Série', horario:'16:00', periodo: 'Vespertino', descricao: 'Física'},
  ];*/



}])

.controller('educaMTCtrl', ['$scope', '$stateParams', // The following is the constructor function for this page's controller. See https://docs.angularjs.org/guide/controller
// You can include any angular dependencies as parameters for this function
// TIP: Access Route Parameters for your page via $stateParams.parameterName
function ($scope, $stateParams) {


}])

.controller('loginCtrl', ['$scope', '$stateParams', // The following is the constructor function for this page's controller. See https://docs.angularjs.org/guide/controller
// You can include any angular dependencies as parameters for this function
// TIP: Access Route Parameters for your page via $stateParams.parameterName
function ($scope, $stateParams) {

}])

.controller('escolasCtrl', ['$scope', '$stateParams',
// The following is the constructor function for this page's controller. See https://docs.angularjs.org/guide/controller
// You can include any angular dependencies as parameters for this function
// TIP: Access Route Parameters for your page via $stateParams.parameterName
function ($scope, $stateParams) {

  var vm = $scope;

  vm.escolas = [{nome: 'Ubaldo Monteiro', id: 1},
                {nome: 'Adalgisa de Barros', id: 2},
                {nome: 'Milton Figueiredo', id: 3}];

}])

.controller('alunosCtrl', ['$scope', '$state', '$stateParams', '$http',
// The following is the constructor function for this page's controller. See https://docs.angularjs.org/guide/controller
// You can include any angular dependencies as parameters for this function
// TIP: Access Route Parameters for your page via $stateParams.parameterName
function ($scope, $state, $stateParams, $http) {

  console.log($stateParams);
  var vm  = $scope;

  vm.idDisciplina = $stateParams.disciplina;
  vm.idProfessor = $stateParams.professor;

  $http.get("http://educamt.azurewebsites.net/professor/" + vm.idProfessor + "/disciplina/" + vm.idDisciplina + "/diario-inicial")
    .success(function(data, status, headers,config){
      vm.alunos = data; // for UI
    })
    .error(function(data, status, headers,config){
      console.log('data error');
    })
    .then(function(result){
      things = result;
  });

  vm.cadastrarFalta = function(aluno) {
    aluno.faltou = true
    console.log(aluno);
  };

  vm.enviarDiario = function() {
    console.log(vm.alunos);

    var data = vm.alunos;

    var config = {
      headers : {
        'Content-Type': 'application/json;charset=utf-8;'
      }
    }

    var config = "";

    $http.post(
        "http://educamt.azurewebsites.net/professor/" + vm.idProfessor + "/disciplina/" + vm.idDisciplina + "/diario",
        data, config)
      .success(function (data, status, headers, config) {
        $scope.PostDataResponse = data;
      })
      .error(function (data, status, header, config) {
        $scope.ResponseDetails = "Data: " + data +
          "<hr />status: " + status +
          "<hr />headers: " + header +
          "<hr />config: " + config;
      });
  };

}])
