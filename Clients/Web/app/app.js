(function ($, jQuery) {
    "use strict";

    window.app = window.app || { resolver: {} };

    var isApp = !!window.cordova;

    // Für Apps wird die Modal-Methode verwandt, für Webseiten die „reguläre“ Weiterleitung.
    var redirectUri = isApp ? 'http://localhost:8080/modal.html' : 'https://localhost:8080/#/tokenReceived?x=x&';
    // Hinweis: ?x=x& ist hier erforderlich, da der OIDC Token Manager aktuell noch keine Weiterleitung
    // an Seiten mit Routing-Frameworks unterstützt. Dieser Workoround kann entfallen,

    window.oidcConfiguration = {
        // client id
        client_id: "angular",

        // redirect URI an den token geschickt wird
        redirect_uri: redirectUri,

        // URI, auf die nach dem Logout zurückgeleitet wird
        post_logout_redirect_uri: 'http://localhost:8080/',

        // ein identity token soll zurückgeliefert werden
        response_type: "id_token token",

        // angefragte scopes
        scope: "openid user_data webapi",

        // basis-pfad zu identityserver (für discovery dokument)
        authority: "http://localhost:8081/"
    };

    app.module = angular.module("authDemo", ["ui.router"]);

    app.module.constant('webApiBaseUrl', 'https://localhost:44347/');
    app.module.constant('isApp', isApp);

    app.module.controller('appController', function ($scope) {
        $scope.page = {
            title: "Cross-Platform Auth Demo"
        };
    });
})();