(function ($, jQuery) {
    "use strict";

    /**
     * @constructor
     * @public
     *
     * @param $scope
     * @param {ProfileApi} profileApi
     * @param {TokenAuthentication} tokenAuthentication
     */
    function ProfileController($scope, profileApi, tokenAuthentication) {
        $scope.page.title = 'Benutzerprofil';

        profileApi.getProfileAsync()
            .then(function (profile) {
                $scope.profile = profile;
            }, function () {
                $scope.hasError = true;
            });

        $scope.logout = function () {
            tokenAuthentication.logout();
        };
    }

    app.module.controller('profileController', ProfileController);
})();