using System.Collections.Generic;
using System.Linq;
using IdentityServer3.Core.Models;

namespace Ajf.IdentityServer3.Config
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            var enumerable = new List<Scope>
            { 
                StandardScopes.OpenId,
                StandardScopes.ProfileAlwaysInclude,
                StandardScopes.Address,
                new Scope
                {
                    Name = "email",
                    DisplayName = "Email",
                    Description = "Get email",
                    Type = ScopeType.Resource,
                    Claims = new List<ScopeClaim>()
                    {
                        new ScopeClaim(StandardScopes.Email.Name, true)
                    },
                },
                new Scope
                { 
                    Name = "gallerymanagement",
                    DisplayName = "Gallery Management",
                    Description = "Allow the application to manage galleries on your behalf.",
                    Type = ScopeType.Resource,
                    Claims = new List<ScopeClaim>()
                    {
                        new ScopeClaim("role", false)
                    },
                },
                new Scope
                { 
                    Name = "roles",
                    DisplayName = "Role(s)",
                    Description = "Allow the application to see your role(s).",
                    Type = ScopeType.Identity,
                    Claims = new List<ScopeClaim>()
                    {
                        new ScopeClaim("role", true)
                    }
                },
                StandardScopes.OfflineAccess
            };
            enumerable.First().Claims.Add(new ScopeClaim(StandardScopes.Email.Name,true));
            return enumerable;
        }
    }
}
