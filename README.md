# Cross-platform authentication
This sample demonstrates cross-platform user authentication using three clients: A WPF desktop application, a website and a mobile client based on HTML5 and JavaScript. On the server side, IdentityServer3 is used to manage the authentication requests. IdentityServer3 implements the OAuth 2.0 and OpenID Connect protocols.

## Server
The server part consists of two components, the IdentityServer3 component and the Web API component. Both components are hosted in an OWIN self host, so you can start regardless of having an active installation of IIS.

In order to run the self hosts, you have to create URL reservations for both hosts using the netsh command. Please run the following commands in an elevated command line and replace `<username>` by your Windows username.

    netsh http add urlacl url=http://+:8080 user=<username>
    netsh http add urlacl url=http://+:8081 user=<username>

## Clients
### Web client
The web client navigates to the IdentityServer3 frontend in order to perform the login and redirects to the website after the request was handled.

In order to run the web client, please run the following two commands in the `Clients/Web` subfolder:

    npm install
    node app.js

### Mobile client
The mobile client based on HTML5 and JavaScript uses a pop-up approach, because the platform’s web view should not navigate away from the app resources. Apart from this, the sources of the mobile client match the sources of the web client. Using Apache Cordova, you can deploy this mobile client to several platforms.

### Desktop client
TBD

## Notes
HTTPS is _disabled_ for testing purposes. DO NOT disable HTTPS in production environments (never do).

## Further reading
* [OAuth 2.0](http://oauth.net/2/)
* [OpenID Connect](http://openid.net/connect/)
* [IdentityServer3 Documentation](https://identityserver.github.io/Documentation/)
* [Enable SSL in OWIN Self Hosts](http://chavli.com/how-to-configure-owin-self-hosted-website-with-ssl/)