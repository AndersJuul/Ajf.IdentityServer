﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ajf.IdentityServer3.Models.Entities;

namespace Ajf.IdentityServer3.Repository
{
    public class UserRepository : IDisposable, IUserRepository
    {
        ApplicationDbContext _ctx;

        public UserRepository(ApplicationDbContext userContext)
        {
            _ctx = userContext;
        }

        public UserRepository()
        {
            // no context passed in, assume default location
            //_ctx = new UserContext(@"app_data/userstore.json");
            _ctx = new ApplicationDbContext();
        }

        public User GetUser(string subject)
        {
            return _ctx
                .Users
                .Include("UserLogins").Include("UserClaims")
                .FirstOrDefault(u => u.Subject.ToLower() == subject.ToLower());
        }

        public User GetUser(string userName, string password)
        {
            return _ctx.Users
                .Include("UserLogins").Include("UserClaims")
                .FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }

        public IList<UserClaim> GetUserClaims(string subject)
        {
            var user = GetUser(subject);
            if (user == null)
            {
                return new List<UserClaim>();
            }

            return user.UserClaims;
        }

        public IList<UserLogin> GetUserLogins(string subject)
        {
            var user = GetUser(subject);
            if (user == null)
            {
                return new List<UserLogin>();
            }

            return user.UserLogins;
        }

        public User GetUserForExternalProvider(string loginProvider, string providerKey)
        {
            foreach (var user in _ctx.Users.Include("UserLogins").Include("UserClaims"))
            {
                if (user.UserLogins.Any(l => l.LoginProvider.ToLowerInvariant() == loginProvider.ToLowerInvariant()
                    && l.ProviderKey.ToLowerInvariant() == providerKey.ToLowerInvariant()))
                {
                    return user;
                }
            }

            return null;
        }

        public User GetUserByEmail(string email)
        {
            foreach (var user in _ctx.Users.Include("UserLogins").Include("UserClaims"))
            {
                if (user.UserClaims.Any(c => c.ClaimType == "email" 
                    && c.ClaimValue.ToLowerInvariant() == email.ToLowerInvariant()))
                {
                    return user;
                }
            }

            return null;
        }
        public void AddUser(User user)
        {
            _ctx.Users.Add(user);

            Save();
        }

        public void AddUserLogin(string subject, string loginProvider, string providerKey)
        {
            // get user
            var user = GetUser(subject);
            if (user == null)
            {
                throw new ArgumentException("User with given subject not found.", subject);
            }

            user.UserLogins.Add(new UserLogin()
            {
                Subject = subject,
                LoginProvider = loginProvider,
                ProviderKey = providerKey
            });

            Save();
        }

        public void AddUserClaim(string subject, string claimType, string claimValue)
        {
            // get user
            var user = GetUser(subject);
            if (user == null)
            {
                throw new ArgumentException("User with given subject not found.", subject);
            }

            user.UserClaims.Add(new UserClaim()
            {
                Id = Guid.NewGuid().ToString(),
                Subject = subject,
                ClaimType = claimType,
                ClaimValue = claimValue
            });

            Save();
        }

        private int Save()
        {
            return _ctx.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_ctx != null)
                {
                    _ctx.Dispose();
                    _ctx = null;
                }

            }
        }
    }
}
