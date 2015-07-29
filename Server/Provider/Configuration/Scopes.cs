using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Models;

namespace Provider.Configuration
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            var userDataScope = new Scope
            {
                Name = "user_data",
                DisplayName = "User data",

                Type = ScopeType.Identity,
                Claims = new List<ScopeClaim>
                {
                    new ScopeClaim("name", alwaysInclude: true),
                    new ScopeClaim("email", alwaysInclude: true),
                    new ScopeClaim("role", alwaysInclude: true)
                }
            };

            var webApiScope = new Scope
            {
                Name = "sample_webapi",
                DisplayName = "Web API",

                Type = ScopeType.Resource,
                Claims = new List<ScopeClaim>
                {
                    new ScopeClaim("name")
                }
            };

            return new List<Scope>
            {
                StandardScopes.OpenId,
                userDataScope,
                webApiScope
            };
        }
    }
}