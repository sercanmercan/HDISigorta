using HDISigorta.Domain.Entities.Common;
using HDISigorta.Domain.Entities.MaintenanceCenters;
using HDISigorta.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDISigorta.Domain.Entities.Maintenance
{
    public class Maintenance : BaseEntity<Guid>
    {
        public Product Product { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Guid ProductId { get; set; }
        public DateTime EntryTime { get; set; } = DateTime.Now;
        public DateTime? CheckOut { get; set; }
        public string Description { get; set; }

        public MaintenanceCenter MaintenanceCenter { get; set; }
        [ForeignKey(nameof(MaintenanceCenterId))]
        public  Guid MaintenanceCenterId { get; set; }
    }
}
