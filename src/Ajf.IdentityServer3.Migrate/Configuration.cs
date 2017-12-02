using System.Configuration;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Claims;
using Ajf.IdentityServer3.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Constants = IdentityServer3.Core.Constants;

namespace Ajf.IdentityServer3.Migrate
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        //private string _frankEmailDk;
        //private string _claireEmailDk;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //_frankEmailDk = "frank@email.dk";
            //_claireEmailDk = "claire@email.dk";

            var env = ConfigurationManager.AppSettings["Environment"];

            if (env!="PROD"&& !context.Users.Any(r => r.UserName == "Kevin"))
            {
                context.Users.Add(new User
                {
                    Id=1,
                    UserName = "Kevin",
                    Password = "secret",
                    Subject = "b05d3546-6ca8-4d32-b95c-77e94d705ddf",
                    IsActive = true,
                    UserClaims = new[]
                    {
                        new UserClaim
                        {
                            Id = "1",
                            ClaimType =Constants.ClaimTypes.GivenName,
                            ClaimValue = "Kevin",
                            Subject = "b05d3546-6ca8-4d32-b95c-77e94d705ddf"
                        },
                        new UserClaim
                        {
                            Id = "2",
                            ClaimType = Constants.ClaimTypes.FamilyName,
                            ClaimValue = "Dockx",
                            Subject = "b05d3546-6ca8-4d32-b95c-77e94d705ddf"
                        },
                        new UserClaim
                        {
                            Id = "3",
                            ClaimType = Constants.ClaimTypes.Address,
                            ClaimValue = "1, Main Street, Antwerp, Belgium",
                            Subject = "b05d3546-6ca8-4d32-b95c-77e94d705ddf"
                        },
                        new UserClaim
                        {
                            Id = "4",
                            ClaimType = "role",
                            ClaimValue = "PayingUser",
                            Subject = "b05d3546-6ca8-4d32-b95c-77e94d705ddf"
                        },
                    }

                });
            }


            //if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "AppAdmin" };

            //    manager.Create(role);
            //}

            //if (!context.Users.Any(u => u.UserName == _claireEmailDk))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser { UserName = _claireEmailDk };

            //    manager.Create(user, "Claire1");
            //    manager.AddToRole(user.Id, "AppAdmin");
            //}
            //if (!context.Users.Any(u => u.UserName == _frankEmailDk))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser { UserName = _frankEmailDk };

            //    manager.Create(user, "Frank1");
            //    manager.AddToRole(user.Id, "AppAdmin");
            //}

            //var userFrank = context.Users.Single(u => u.UserName == _frankEmailDk);

            //var events = new[]
            //{
            //    new Event
            //    {
            //        Description = "First event" + DateTime.Now,
            //        OwnerUserId = userFrank.Id,
            //        TimeFrom = DateTime.Now.AddDays(1),
            //        TimeTo = DateTime.Now.AddDays(1).AddHours(1),
            //        CreateTime = DateTime.Now,
            //        Cars = new Collection<Car>(),
            //        Passengers = new Collection<Passenger>()
            //    },
            //    new Event
            //    {
            //        Description = "Second event" + DateTime.Now,
            //        OwnerUserId = userFrank.Id,
            //        TimeFrom = DateTime.Now.AddDays(2),
            //        TimeTo = DateTime.Now.AddDays(2).AddHours(1),
            //        CreateTime = DateTime.Now,
            //        Cars = new Collection<Car>(),
            //        Passengers = new Collection<Passenger>()
            //    }
            //};

            //context.Events.AddOrUpdate(e => e.Description, events);
        }
    }
}