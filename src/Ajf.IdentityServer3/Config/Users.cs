﻿//using System.Collections.Generic;
//using System.Security.Claims;
//using IdentityServer3.Core;
//using IdentityServer3.Core.Services.InMemory;

//namespace Ajf.IdentityServer3.Config
//{
//    public static class Users
//    {
//        public static List<InMemoryUser> Get()
//        {
//            return new List<InMemoryUser>() {
                 
//                new InMemoryUser
//	            {
//	                Username = "Kevin",
//	                Password = "secret",                    
//	                Subject = "b05d3546-6ca8-4d32-b95c-77e94d705ddf",
//                    Claims = new[]
//                    {
//                        new Claim(Constants.ClaimTypes.GivenName, "Kevin"),
//                        new Claim(Constants.ClaimTypes.FamilyName, "Dockx"),
//                        new Claim(Constants.ClaimTypes.Address, "1, Main Street, Antwerp, Belgium"),
//                        new Claim("role", "PayingUser")                  ,
//                        new Claim(Constants.ClaimTypes.Email,"kevin@dockx.dk")
//                    }
//	             }
//	            ,
//	            new InMemoryUser
//	            {
//	                Username = "Sven",
//	                Password = "secret",
//	                Subject = "bb61e881-3a49-42a7-8b62-c13dbe102018",
//                    Claims = new[]
//                    {
//                        new Claim(Constants.ClaimTypes.GivenName, "Sven"),
//                        new Claim(Constants.ClaimTypes.FamilyName, "Vercauteren"),
//                        new Claim(Constants.ClaimTypes.Address, "2, Main Road, Antwerp, Belgium"),
//                        new Claim("role", "FreeUser"),
//                        new Claim(Constants.ClaimTypes.Email,"sven@dockx.dk")
//                    }
//                }  
//            };
//        }
//    }

//}
