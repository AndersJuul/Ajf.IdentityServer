using System.Linq;
using System.Threading.Tasks;
using IdentityServer.WindowsAuthentication.Services;

namespace Ajf.WSFederationServer.Services
{
    public class AdditionalWindowsClaimsProvider : ICustomClaimsProvider
    {
        public Task TransformAsync(CustomClaimsProviderContext context)
        {
            // find name claim on outgoing subject
            var nameClaim = context.OutgoingSubject.Claims.FirstOrDefault(c => c.Type == "name");
            if (nameClaim!= null && nameClaim.Value == @"MARVIN-SURFACE\Kevin")
            {
                // add an e-mail claim to the outgoing claims 
                context.OutgoingSubject.AddClaim(
                    new System.Security.Claims.Claim("email", "tom.dockx@someprovider.com"));
            }

            return Task.FromResult(0);
        }
    }
}
