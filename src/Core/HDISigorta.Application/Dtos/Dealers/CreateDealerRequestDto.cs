using HDISigorta.Application.Dtos.AppUser.CreateUser;

namespace HDISigorta.Application.Dtos.Dealers
{
    public class CreateDealerRequestDto
    {
        public string FullAdress { get; set; }
        public string DealerName { get; set; }

        public bool IsCheckValid()
        {
            if (string.IsNullOrWhiteSpace(FullAdress) || string.IsNullOrWhiteSpace(DealerName))
                    return false;
            return true;
        }
    }
}
