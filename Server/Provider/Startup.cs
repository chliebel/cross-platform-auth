using Owin;
using Provider.Configuration;
using Thinktecture.IdentityServer.Core.Configuration;
using Thinktecture.IdentityServer.Core.Services;
using Thinktecture.IdentityServer.Core.Services.InMemory;

namespace Provider
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var factory = new IdentityServerServiceFactory();

			var users = new InMemoryUserService(Users.Get());
			var scopes = new InMemoryScopeStore(Scopes.Get());
			var clients = new InMemoryClientStore(Clients.Get());
			var cors = new InMemoryCorsPolicyService(Clients.Get());

			factory.UserService = new Registration<IUserService>(users);
			factory.ScopeStore = new Registration<IScopeStore>(scopes);
			factory.ClientStore = new Registration<IClientStore>(clients);
			factory.CorsPolicyService = new Registration<ICorsPolicyService>(cors);

			var options = new IdentityServerOptions
			{
				SigningCertificate = Certificate.Get(),
				SiteName = "Cross-Platform Auth Demo",
				Factory = factory,
				// TODO: DO NOT disable SSL in production!!
				RequireSsl = false
			};

			app.UseIdentityServer(options);
		}
	}
}