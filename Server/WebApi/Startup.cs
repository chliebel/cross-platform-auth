using System.Web.Http;
using System.Web.Http.Cors;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using Thinktecture.IdentityServer.AccessTokenValidation;

namespace WebApi
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var options = GetAuthenticationOptions();
			app.UseIdentityServerBearerTokenAuthentication(options);

			var container = GetAutofacContainerBuilder();
			var webApiConfig = ConfigureWebApi(container);
			app.UseWebApi(webApiConfig);
		}

		public IdentityServerBearerTokenAuthenticationOptions GetAuthenticationOptions()
		{
			return new IdentityServerBearerTokenAuthenticationOptions
			{
				Authority = "http://localhost:8081",
				RequiredScopes = new[] { "webapi" }
			};
		}

		public IContainer GetAutofacContainerBuilder()
		{
			var builder = new ContainerBuilder();
			builder.RegisterApiControllers(GetType().Assembly);

			return builder.Build();
		}

		public HttpConfiguration ConfigureWebApi(IContainer container)
		{
			var config = new HttpConfiguration();
			config.Routes.MapHttpRoute("Default", "api/{controller}/{action}");
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

			config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

			return config;
		}
	}
}