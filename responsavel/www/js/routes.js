angular.module('app.routes', [])

.config(function($stateProvider, $urlRouterProvider) {

  // Ionic uses AngularUI Router which uses the concept of states
  // Learn more here: https://github.com/angular-ui/ui-router
  // Set up the various states which the app can be in.
  // Each state's controller can be found in controllers.js
  $stateProvider
    
  

   .state('tabsController', {
    url: '/page1',
    templateUrl: 'templates/tabsController.html',
    abstract:true
  })

  .state('relatorio', {
    url: '/relatorio?filho&?responsavelId',
    templateUrl: 'templates/relatorio.html',
    controller: 'relatorioCtrl'
  })

  .state('filhos', {
    url: '/filhos?responsavelId',
    templateUrl: 'templates/filhos.html',
    controller: 'filhosCtrl'
  })

  .state('login', {
    url: '/login',
    templateUrl: 'templates/login.html',
    controller: 'loginCtrl'
  })

$urlRouterProvider.otherwise('/login')

  

});