namespace HDISigorta.Application.Exceptions
{
    public class UserCreateFailedException : Exception
    {
        public UserCreateFailedException() 
            //: base("Kullanici oluşturulurken beklenmeyen bir hata olustu.")
        {
        }

        public UserCreateFailedException(string? message) : base(message)
        {
        }
    }
}
