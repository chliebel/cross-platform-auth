using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Models;

namespace Provider.Configuration
{
	public class Clients
	{
		public static IEnumerable<Client> Get()
		{
			var web = new Client
			{
				ClientName = "AngularJS Web Client",
				ClientId = "angular-web",
				Flow = Flows.Implicit,

				RedirectUris = new List<string>
				{
					"http://localhost:8080/#/tokenReceived?x=x&"
				},

				PostLogoutRedirectUris = new List<string>
				{
					"http://localhost:8080/"
				}
			};

			var mobile = new Client
			{
				ClientName = "AngularJS App Client",
				ClientId = "angular-app",
				Flow = Flows.Implicit,

				RedirectUris = new List<string>
				{
					"oob://localhost/appclient"
				},
				

				PostLogoutRedirectUris = new List<string>
				{
					"oob://localhost/appclient/logout"
				}
			};

			var desktop = new Client
			{
				ClientName = "WPF Client",
				ClientId = "wpf",
				Flow = Flows.Implicit,

				RedirectUris = new List<string>
				{
					"oob://localhost/wpfclient"
				},

				PostLogoutRedirectUris = new List<string>
				{
					"oob://localhost/wpfclient/logout"
				}
			};

			return new List<Client>
			{
				web,
				mobile,
				desktop
			};
		}
	}
}