using HDISigorta.Domain.Entities.Common;

namespace HDISigorta.Domain.Entities.Dealers
{
    public class Dealer : BaseEntity<Guid>
    {
        public string FullAdress { get; set; }
        public string DealerName { get; set; }
    }
}
