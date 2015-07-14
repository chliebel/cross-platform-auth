(function ($, jQuery) {
    "use strict";

    /**
     * @constructor
     * @public
     *
     * @param $scope
     * @param {TokenAuthentication} tokenAuthentication
     * @param {Boolean} isApp
     */
    function MainController($scope, tokenAuthentication, isApp) {
        $scope.page.title = "Cross-Platform Auth Demo";
        $scope.login = tokenAuthentication.login;
        
        $scope.welcomeText = isApp ? 'Willkommen in meiner App' : 'Willkommen auf meiner Website';
    }

    app.module.controller('mainController', MainController);
})();