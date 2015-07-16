(function ($, jQuery) {
    "use strict";

    /**
     * @ngdoc service
     * @public
     *
     * @param $http
     * @param $q
     * @param webApiBaseUrl
     * @param {TokenAuthentication} tokenAuthentication
     **/
    function ProfileApi($http, $q, webApiBaseUrl, tokenAuthentication) {
        this.getProfileAsync = function () {
            return $http.get(webApiBaseUrl + 'api/Profile/GetProfile', {
                headers: {
                    'Authorization': 'Bearer ' + tokenAuthentication.getAccessToken()
                }
            }).then(function (result) {
                return result.data;
            }, function (err) {
                console.log(err);
                return $q.reject(err);
            });
        };
    }

    app.module.service('profileApi', ProfileApi);
})();