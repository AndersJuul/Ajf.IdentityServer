using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace Ajf.IdentityServer3.Config
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>
                { 
                    StandardScopes.OpenId,
                    StandardScopes.ProfileAlwaysInclude,
                    StandardScopes.Address,                     
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
        }
    }
}
