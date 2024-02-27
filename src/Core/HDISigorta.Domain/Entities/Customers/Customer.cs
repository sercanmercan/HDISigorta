using HDISigorta.Domain.Entities.Common;
using HDISigorta.Domain.Entities.Dealers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDISigorta.Domain.Entities.Customers
{
    public class Customer : BaseEntity<Guid>
    {
        [MaxLength(11)]
        public string IdentityNumber { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }

        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        //Hangi bayiden satış yapıldı.
        public Dealer Dealer { get; set; }
        [ForeignKey(nameof(DealerId))]
        public Guid DealerId { get; set; }
    }
}
