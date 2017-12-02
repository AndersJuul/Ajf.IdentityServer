using System.ComponentModel.DataAnnotations;

namespace Ajf.IdentityServer3.Models.Entities
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }

    }
}
