﻿using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace Ajf.IdentityServer3.Config
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "tripgalleryclientcredentials",
                    ClientName = "Trip Gallery (Client Credentials)",
                    Flow = Flows.ClientCredentials,
                    AllowAccessToAllScopes = true,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("myrandomclientsecret".Sha256())
                    }
                },
                new Client
                {
                    ClientId = "tripgalleryauthcode",
                    ClientName = "Trip Gallery (Authorization Code)",
                    Flow = Flows.AuthorizationCode,
                    AllowAccessToAllScopes = true,

                    // redirect = URI of our callback controller in the MVC application
                    RedirectUris = new List<string>
                    {
                        "https://localhost/Ajf.RideShare.Web/stscallback"
                    },

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("myrandomclientsecret".Sha256())
                    }
                },
                new Client
                {
                    ClientId = "tripgalleryimplicit",
                    ClientName = "Trip Gallery (Implicit)",
                    Flow = Flows.Implicit,
                    AllowAccessToAllScopes = true,
                    IdentityTokenLifetime = 10,
                    AccessTokenLifetime = 120,
                    RequireConsent = false,

                    // redirect = URI of the Angular application
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44316/" + "callback.html",
                        // for silent refresh
                        "https://localhost:44316/" + "silentrefreshframe.html"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44316/" + "index.html"
                    }
                },
                new Client
                {
                    ClientId = "tripgalleryropc",
                    ClientName = "Trip Gallery (Resource Owner Password Credentials)",
                    Flow = Flows.ResourceOwner,
                    AllowAccessToAllScopes = true,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("myrandomclientsecret".Sha256())
                    }
                },
                new Client
                {
                    ClientId = "tripgalleryhybrid",
                    ClientName = "Trip Gallery (Hybrid)",
                    Flow = Flows.Hybrid,
                    AllowAccessToAllScopes = true,
                    IdentityTokenLifetime = 10,
                    AccessTokenLifetime = 120,
                    RequireConsent = false,

                    // redirect = URI of the MVC application
                    RedirectUris = new List<string>
                    {
                        //"https://localhost/Ajf.RideShare.Web/",
                        //"http://ajf-qa-02/RideShare/",
                        //"https://andersathome.dk/RideShare/",

                        //"https://localhost/HansJuergenWeb/",
                        //"http://ajf-qa-02/HansJuergenWeb/",
                        //"https://andersathome.dk/HansJuergenWeb/"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        //"https://localhost/Ajf.RideShare.Web",
                        //"http://ajf-qa-02/RideShare/",
                        //"https://andersathome.dk/RideShare/",

                        //"https://localhost/HansJuergenWeb/",
                        //"http://ajf-qa-02/HansJuergenWeb/",
                        //"https://andersathome.dk/HansJuergenWeb/"
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("myrandomclientsecret".Sha256())
                    }
                },
                new Client
                {
                    ClientId = "mvc.owin.hybrid",
                    ClientName = "mvc.owin.hybrid",
                    Flow = Flows.Hybrid,
                    AllowAccessToAllScopes = true,
                    IdentityTokenLifetime = 10,
                    AccessTokenLifetime = 120,
                    RequireConsent = false,

                    // redirect = URI of the MVC application
                    RedirectUris = new List<string>
                    {
                        "http://localhost:49314/",
                        "http://ajf-qa-02/Ajf.MvcTestClient.Mvc/",
                        "https://andersathome.dk/Ajf.MvcTestClient.Mvc/"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:49314/",
                        "http://ajf-qa-02/Ajf.MvcTestClient.Mvc/",
                        "https://andersathome.dk/Ajf.MvcTestClient.Mvc/"
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    }
                },
                new Client
                {
                    ClientId = "ridesharehybrid",
                    ClientName = "RideShare (Hybrid)",
                    Flow = Flows.Hybrid,
                    AllowAccessToAllScopes = true,
                    IdentityTokenLifetime = 10,
                    AccessTokenLifetime = 120,
                    RequireConsent = false,

                    // redirect = URI of the MVC application
                    RedirectUris = new List<string>
                    {
                        "https://localhost/Ajf.RideShare.Web/",
                        "http://ajf-qa-02/RideShare/",
                        "https://andersathome.dk/RideShare/"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost/Ajf.RideShare.Web",
                        "http://ajf-qa-02/RideShare/",
                        "https://andersathome.dk/RideShare/"
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("myrandomclientsecret".Sha256())
                    }
                },

                new Client
                {
                    ClientId = "hjhwebhybrid",
                    ClientName = "Hans Juergen Web (Hybrid)",
                    Flow = Flows.Hybrid,
                    AllowAccessToAllScopes = true,
                    IdentityTokenLifetime = 10,
                    AccessTokenLifetime = 120,
                    RequireConsent = false,

                    // redirect = URI of the MVC application
                    RedirectUris = new List<string>
                    {
                        "https://localhost/HansJuergenWeb/",
                        "http://ajf-qa-02/HansJuergenWeb/",
                        "https://andersathome.dk/hjweb/"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost/HansJuergenWeb/",
                        "http://ajf-qa-02/HansJuergenWeb/",
                        "https://andersathome.dk/hjweb/"
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("myrandomclientsecret".Sha256())
                    }
                }
            };
        }
    }
}