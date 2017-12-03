using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using Ajf.WSFederationServer.Services;
using IdentityServer.WindowsAuthentication.Configuration;
using Owin;

namespace Ajf.WSFederationServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWindowsAuthenticationService(new WindowsAuthenticationOptions
            {
                IdpRealm = "urn:win",
                IdpReplyUrl = ConfigurationManager.AppSettings["IdentityServerUrl"] + "/was",
                PublicOrigin = "https://localhost:44330/",
                SigningCertificate = LoadCertificate(),
                CustomClaimsProvider = new AdditionalWindowsClaimsProvider()
            });
        }


        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\certificates\idsrv3test.pfx",
                AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}
