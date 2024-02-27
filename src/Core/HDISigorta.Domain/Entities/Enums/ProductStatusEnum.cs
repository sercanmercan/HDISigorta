using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDISigorta.Domain.Entities.Enums
{
    public enum ProductStatusEnum
    {
        [Description("satıldı")]
        SoldOut = 1,

        [Description("stokta var")]
        InStock = 2
    }
}
