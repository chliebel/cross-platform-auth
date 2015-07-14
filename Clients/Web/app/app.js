(function ($, jQuery) {
    "use strict";

    window.app = window.app || { resolver: {} };

    window.oidcConfiguration = {
        // client id
        client_id: "angular",

        // redirect URI an den token geschickt wird
        redirect_uri: "http://localhost:8080/modal.html",
        // Für Redirect-Methode:
        //redirect_uri: "https://localhost:8080/#/tokenReceived?x=x&",
        // Hinweis: ?x=x& ist hier erforderlich, da der OIDC Token Manager keine Kenntnis über den
        // Aufbau von Routen-Parametern für UI-Router besitzt und den Location-Hash starr an allen
        // Kaufmannsund-Zeichen (&) splittet, und nicht am Fragezeichen

        // URI, auf die nach dem Logout zurückgeleitet wird
        post_logout_redirect_uri: 'http://localhost:8080/',

        // ein identity token soll zurückgeliefert werden
        response_type: "id_token token",

        // angefragte scopes
        scope: "openid user_data webapi",

        // basis-pfad zu identityserver (für discovery dokument)
        authority: "http://localhost:8081/",

        // zu Demonstrationszwecken: alle Claims speichern/anzeigen
        filter_protocol_claims: false
    };

    app.module = angular.module("authDemo", ["ui.router"]);

    app.module.constant('webApiBaseUrl', 'https://localhost:44347/');
    app.module.constant('isApp', false);

    app.module.controller('appController', function ($scope) {
        $scope.page = {
            title: "Cross-Platform Auth Demo"
        };
    });
})();