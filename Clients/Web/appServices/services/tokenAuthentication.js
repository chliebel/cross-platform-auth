(function ($, jQuery) {
    "use strict";

    /**
     * @ngdoc service
     * @public
     *
     * @param $window
     * @param $state
     * @param $rootScope
     * @param {Boolean} isApp
     * @param oidcConfigJson
     **/
    function TokenAuthentication($window, $state, $rootScope, isApp, oidcConfigJson) {
        var manager;
        var popup;

        loadManager();
        function loadManager() {
            manager = new OidcTokenManager($window.oidcConfiguration);
        }

        this.login = function () {
            if (isApp) {
                popup = $window.open('modal.html#' + encodeURIComponent(oidcConfigJson), '_blank', 'location=no;EnableViewPortScale=yes');
                popup.addEventListener('loadstart', function (event) {
                    alert(event.url);
                    var redirectUriIndex = event.url.indexOf($window.oidcConfiguration.redirect_uri);
                    if (redirectUriIndex !== -1) {
                        manager.processTokenCallbackAsync(event.url.substr(redirectUriIndex))
                            .then(function () {
                                popup.close();
                                $state.go('profile');
                            });
                    }
                });
            } else {
                manager.redirectForToken();
            }
        };

        $window.onLogin = function () {
            // Popup schließen und zu Login-Seite navigieren
            loadManager();
            popup.close();
            $state.go('login');
        };

        this.checkTokenAsync = function () {
            return manager.processTokenCallbackAsync();
        };
        
        this.getAccessToken = function () {
            return manager.access_token;
        };

        this.logout = function () {
            manager.redirectForLogout();
        };

        $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
            // Wenn der State nicht als anonym markiert ist und kein Identity-Token hinterlegt ist, State-Wechsel abbrechen
            if (!toState.anonymous && !manager.id_token) {
                event.preventDefault();
            }
        });
    }

    app.module.service('tokenAuthentication', TokenAuthentication);
})();