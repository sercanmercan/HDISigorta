using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDISigorta.Domain.Entities.Enums
{
    public enum DepartmentEnum
    {
        [Description("bayi")]
        Dealer = 1,

        [Description("tamirci")]
        Maintenance = 2,

        [Description("IT")]
        IT = 3
    }
}
