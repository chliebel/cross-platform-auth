using System.Collections.Generic;
using System.Security.Claims;
using Thinktecture.IdentityServer.Core.Services.InMemory;

namespace Provider.Configuration
{
    public class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject = "1",
                    Username = "alice",
                    Password = "secret",
                    Claims = new List<Claim>
                    {
                        new Claim("name", "Alice Smith"),
                        new Claim("email", "alice@example.com"),
                        new Claim("role", "Operations")
                    }
                }
            };
        }  
    }
}