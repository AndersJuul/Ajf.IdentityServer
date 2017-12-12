using Ajf.IdentityServer3.Models.Entities;

namespace Ajf.IdentityServer3.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void AddUserClaim(string subject, string claimType, string claimValue);
        void AddUserLogin(string subject, string loginProvider, string providerKey);
        void Dispose();
        User GetUser(string subject);
        User GetUser(string userName, string password);
        System.Collections.Generic.IList<UserClaim> GetUserClaims(string subject);
        User GetUserForExternalProvider(string loginProvider, string providerKey);
        User GetUserByEmail(string email);
        System.Collections.Generic.IList<UserLogin> GetUserLogins(string subject);
    }
}
