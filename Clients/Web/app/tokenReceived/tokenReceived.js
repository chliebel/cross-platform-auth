(function ($, jQuery) {
    "use strict";

    /**
     * Used for redirect-based authentication
     *
     * @constructor
     * @public
     *
     * @param $scope
     * @param $state
     * @param {TokenAuthentication} tokenAuthentication
     */
    function TokenReceivedController($scope, $state, tokenAuthentication) {
        $scope.page.title = 'Weiterleitung…';

        tokenAuthentication.checkTokenAsync()
            .then(function () {
                $state.go('profile');
            });
    }

    app.module.controller('tokenReceivedController', TokenReceivedController);
})();