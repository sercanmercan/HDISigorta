using HDISigorta.Domain.Entities.Identities;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDISigorta.Domain.Entities.MaintenanceCenters
{
    public class MaintenanceCenter
    {
        public ICollection<AppUser> AppUsers { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
    }
}
