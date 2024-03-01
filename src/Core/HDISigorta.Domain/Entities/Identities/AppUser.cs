using Microsoft.AspNetCore.Identity;

namespace HDISigorta.Domain.Entities.Identities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public Guid DealerId { get; set; }

    }
}
