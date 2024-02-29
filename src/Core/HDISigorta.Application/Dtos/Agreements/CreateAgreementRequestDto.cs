namespace HDISigorta.Application.Dtos.Agreements
{
    public class CreateAgreementRequestDto
    {
        public string Name { get; set; }

        //Garanti içeriği
        public string Description { get; set; }

        //Geçerlilik süresi
        public int ValidityPeriod { get; set; }

        public bool IsCheckValid()
        {
            if(string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Description) || ValidityPeriod <= 0)
                return false;
            return true;
        }
    }
}
