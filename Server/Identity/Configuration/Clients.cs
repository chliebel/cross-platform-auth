using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Models;

namespace Identity.Configuration
{
	public class Clients
	{
		public static IEnumerable<Client> Get()
		{
			var web = new Client
			{
				ClientName = "AngularJS Client",
				ClientId = "angular",
				Flow = Flows.Implicit,

				RedirectUris = new List<string>
				{
					"https://localhost:44300/modal.html",
					"https://localhost:44300/#/tokenReceived?x=x&"
				},

				AllowedCorsOrigins = new List<string>
				{
					"https://localhost:44300"
				},

				PostLogoutRedirectUris = new List<string>
				{
					"https://localhost:44300/"
				}
			};

			var mobile = new Client
			{

			};

			var desktop = new Client
			{

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