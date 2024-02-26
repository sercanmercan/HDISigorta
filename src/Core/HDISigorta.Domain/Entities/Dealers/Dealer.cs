using HDISigorta.Domain.Entities.Common;
using HDISigorta.Domain.Entities.Identities;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDISigorta.Domain.Entities.Dealers
{
    public class Dealer : BaseEntity<Guid>
    {
        public ICollection<AppUser> AppUsers { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
    }
}
