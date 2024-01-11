namespace Posts.Challenge.Domain.Exceptions
{
    public class UserRegisterValidationException : Exception
    {
        public UserRegisterValidationException(string error) : base(error)
        {

        }
    }
}
