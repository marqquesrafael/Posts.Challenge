namespace Posts.Challenge.Domain.Exceptions
{
    public class NewPostValidatationException : Exception
    {
        public NewPostValidatationException(string error) : base(error) { }

    }
}
