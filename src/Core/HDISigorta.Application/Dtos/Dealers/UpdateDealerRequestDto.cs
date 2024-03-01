using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDISigorta.Application.Dtos.Dealers
{
    public class UpdateDealerRequestDto
    {
        public Guid Id { get; set; }
        public string FullAdress { get; set; }
        public string DealerName { get; set; }

        public bool IsCheckValid()
        {
            if (Id == Guid.Empty || string.IsNullOrWhiteSpace(FullAdress) || string.IsNullOrWhiteSpace(DealerName))
                return false;
            return true;
        }
    }
}
