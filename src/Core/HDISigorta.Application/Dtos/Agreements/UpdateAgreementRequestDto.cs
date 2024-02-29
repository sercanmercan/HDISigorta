using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDISigorta.Application.Dtos.Agreements
{
    public class UpdateAgreementRequestDto : CreateAgreementRequestDto
    {
        public Guid Id { get; set; }
    }
}
