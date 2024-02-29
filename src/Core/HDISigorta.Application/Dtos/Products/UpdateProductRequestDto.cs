using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDISigorta.Application.Dtos.Products
{
    public class UpdateProductRequestDto : CreateProductRequestDto
    {
        public Guid Id { get; set; }
    }
}
