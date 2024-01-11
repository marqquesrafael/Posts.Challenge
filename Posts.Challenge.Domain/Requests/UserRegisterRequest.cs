namespace Posts.Challenge.Domain.Requests
{
    public class UserRegisterRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Type { get; set; }
    }
}
