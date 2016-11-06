angular.module('app.routes', [])

.config(function($stateProvider, $urlRouterProvider) {

  // Ionic uses AngularUI Router which uses the concept of states
  // Learn more here: https://github.com/angular-ui/ui-router
  // Set up the various states which the app can be in.
  // Each state's controller can be found in controllers.js
  $stateProvider

  .state('disciplinas', {
    url: '/page4?escola',
    templateUrl: 'templates/disciplinas.html',
    controller: 'disciplinasCtrl'
  })

  .state('tabsController', {
    url: '/page1',
    templateUrl: 'templates/tabsController.html',
    abstract:true
  })

  .state('login', {
    url: '/page5',
    templateUrl: 'templates/login.html',
    controller: 'loginCtrl'
  })

  .state('escolas', {
    url: '/page6',
    templateUrl: 'templates/escolas.html',
    controller: 'escolasCtrl'
  })

  .state('alunos', {
    url: '/page7?disciplina&professor',
    templateUrl: 'templates/alunos.html',
    controller: 'alunosCtrl'
  })

$urlRouterProvider.otherwise('/page5')



});
