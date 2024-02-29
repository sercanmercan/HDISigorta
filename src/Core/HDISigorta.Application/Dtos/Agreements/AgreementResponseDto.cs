using HDISigorta.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDISigorta.Application.Dtos.Agreements
{
    public class AgreementResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //Garanti içeriği
        public string Description { get; set; }

        //Geçerlilik süresi
        public int ValidityPeriod { get; set; }

        public List<Product> Products { get; set; }
    }
}
