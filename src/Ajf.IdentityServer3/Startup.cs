using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Ajf.IdentityServer3.Config;
using Ajf.IdentityServer3.Services;
using Ajf.Nuget.Logging;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Default;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Newtonsoft.Json;
using Owin;
using Serilog;
using TripCompany.IdentityServer;
using Constants = IdentityServer3.Core.Constants;

namespace Ajf.IdentityServer3
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Log.Logger = StandardLoggerConfigurator
                .GetLoggerConfig().MinimumLevel
                .Debug()
                .CreateLogger();

            Log.Logger.Information("Starting...");
            Log.Logger.Information("Version is... " + ConfigurationManager.AppSettings["ReleaseNumber"]);

            app.Map("/identity", idsrvApp =>
            {
                var corsPolicyService = new DefaultCorsPolicyService
                {
                    AllowAll = true
                };

                var defaultViewServiceOptions = new DefaultViewServiceOptions();
                defaultViewServiceOptions.CacheViews = false;

                var idServerServiceFactory = new IdentityServerServiceFactory()
                    .UseInMemoryClients(Clients.Get())
                    .UseInMemoryScopes(Scopes.Get());
                //  .UseInMemoryUsers(Users.Get());

                idServerServiceFactory.CorsPolicyService = new
                    Registration<ICorsPolicyService>(corsPolicyService);

                idServerServiceFactory.ConfigureDefaultViewService(defaultViewServiceOptions);

                // use custom UserService
                var customUserService = new CustomUserService();
                idServerServiceFactory.UserService = new Registration<IUserService>(resolver => customUserService);

                var options = new IdentityServerOptions
                {
                    RequireSsl = ConfigurationManager.AppSettings["RequireSsl"] == "true",
                    Factory = idServerServiceFactory,
                    SiteName = "Ajf Security Token Service",
                    SigningCertificate = LoadCertificate(),
                    IssuerUri = "https://andersathome.dk/identity",
                    PublicOrigin = ConfigurationManager.AppSettings["IdentityServerUrl"],
                    AuthenticationOptions = new AuthenticationOptions
                    {
                        EnablePostSignOutAutoRedirect = true,
                        LoginPageLinks = new List<LoginPageLink>
                        {
                            new LoginPageLink
                            {
                                Type = "createaccount",
                                Text = "Create a new account",
                                Href = "~/createuseraccount"
                            }
                        },
                        IdentityProviders = ConfigureAdditionalIdProviders,
                        EnableLocalLogin = ConfigurationManager.AppSettings["EnableLocalLogin"] == "true"
                    },
                    CspOptions = new CspOptions
                    {
                        Enabled = false
                        // once available, leave Enabled at true and use:
                        // FrameSrc = "https://localhost/Ajf.RideShare.Web https://localhost:44316"
                        // or
                        // FrameSrc = "*" for all URI's.
                    }
                };

                idsrvApp.UseIdentityServer(options);
            });
        }

        private void ConfigureAdditionalIdProviders(IAppBuilder appBuilder, string signInAsType)
        {
            var fbAuthOptions = new FacebookAuthenticationOptions
            {
                AuthenticationType = "Facebook",
                SignInAsAuthenticationType = signInAsType,
                AppId = "817115168495325",
                AppSecret = "e7341ec68c4622a8cde93ad089452710",
                Provider = new FacebookAuthenticationProvider
                {
                    OnAuthenticated = context =>
                    {
                        using (var client = new HttpClient())
                        {
                            // get claims from FB's graph 

                            var result = client
                                .GetAsync(
                                    "https://graph.facebook.com/me?fields=first_name,last_name,email&access_token="
                                    + context.AccessToken).Result;

                            if (result.IsSuccessStatusCode)
                            {
                                var userInformation = result.Content.ReadAsStringAsync().Result;
                                var fbUser = JsonConvert.DeserializeObject<FacebookUser>(userInformation);

                                context.Identity.AddClaim(new Claim(
                                    Constants.ClaimTypes.GivenName, fbUser.first_name));
                                context.Identity.AddClaim(new Claim(
                                    Constants.ClaimTypes.FamilyName, fbUser.last_name));
                                context.Identity.AddClaim(new Claim(
                                    Constants.ClaimTypes.Email, fbUser.email));
                            }
                        }

                        return Task.FromResult(0);
                    }
                }
            };
            fbAuthOptions.Scope.Add("email");

            //appBuilder.UseFacebookAuthentication(fbAuthOptions);

            appBuilder.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                AuthenticationType = "Google",
                Caption = "Sign-in with Google",
                SignInAsAuthenticationType = signInAsType,
                Provider = new GoogleOAuth2AuthenticationProvider
                {
                    OnAuthenticated = context =>
                    {
                        context.Identity.AddClaim(new Claim("urn:google:name",
                            context.Identity.FindFirstValue(ClaimTypes.Name)));
                        context.Identity.AddClaim(new Claim("urn:google:email",
                            context.Identity.FindFirstValue(ClaimTypes.Email)));

                        return Task.FromResult(0);
                    }
                },
                ClientId = "827505327283-u8lgot2devkkk6qbuivpe23mmpdjirip.apps.googleusercontent.com",
                ClientSecret = "CZbcrM2E0gP6exLzGu4Y5-Vy"
            });
            //var windowsAuthentication = new WsFederationAuthenticationOptions
            //{
            //    AuthenticationType = "windows",
            //    Caption = "Windows",
            //    SignInAsAuthenticationType = signInAsType,
            //    MetadataAddress = "https://localhost/Ajf.WSFederationServer/",
            //    Wtrealm = "urn:win"

            //};
            //appBuilder.UseWsFederationAuthentication(windowsAuthentication);
        }


        private X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\certificates\idsrv3test.pfx",
                    AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}