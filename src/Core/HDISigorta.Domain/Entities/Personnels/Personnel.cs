using HDISigorta.Domain.Entities.Common;
using HDISigorta.Domain.Entities.Enums;
using HDISigorta.Domain.Entities.Identities;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDISigorta.Domain.Entities.Personnels
{
    public class Personnel : BaseEntity<Guid>
    {
        public DepartmentEnum DepartmentType { get; set; }
        public AppUser AppUsers { get; set; }
        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }
    }
}
