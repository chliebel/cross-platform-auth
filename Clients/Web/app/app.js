(function ($, jQuery) {
    "use strict";

    window.app = window.app || { resolver: {} };

    var isApp = !!window.cordova;

    var clientId = isApp ? 'angular-app' : 'angular-web';

    // Für Apps wird die Modal-Methode verwandt, für Webseiten die „reguläre“ Weiterleitung.
    var redirectUri = isApp ? 'oob://localhost/appclient' : 'http://localhost:8080/#/tokenReceived?x=x&';
    // Hinweis: ?x=x& ist hier erforderlich, da der OIDC Token Manager aktuell noch keine Weiterleitung
    // an Seiten mit Routing-Frameworks unterstützt. Dieser Workoround kann entfallen,

    var webApiBaseUrl = isApp? 'http://10.211.55.3:8082/' : 'http://localhost:8082/';

    window.oidcConfiguration = {
        // client id
        client_id: clientId,

        // redirect URI an den token geschickt wird
        redirect_uri: redirectUri,

        // URI, auf die nach dem Logout zurückgeleitet wird
        post_logout_redirect_uri: 'http://localhost:8080/',

        // ein identity token soll zurückgeliefert werden
        response_type: "id_token token",

        // angefragte scopes
        scope: "openid user_data sample_webapi",

        // basis-pfad zu identityserver (für discovery dokument)
        authority: "http://10.211.55.3:8081/"
    };

    app.module = angular.module("authDemo", ["ui.router"]);

    app.module.constant('webApiBaseUrl', webApiBaseUrl);
    app.module.constant('isApp', isApp);
    app.module.constant('oidcConfigJson', JSON.stringify(window.oidcConfiguration));

    app.module.controller('appController', function ($scope) {
        $scope.page = {
            title: "Cross-Platform Auth Demo"
        };
    });
})();