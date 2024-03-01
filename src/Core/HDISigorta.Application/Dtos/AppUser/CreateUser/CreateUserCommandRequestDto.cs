namespace HDISigorta.Application.Dtos.AppUser.CreateUser
{
    public class CreateUserCommandRequestDto
    {
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public Guid DealerId { get; set; }
    }
}
