namespace Posts.Challenge.Domain.Requests.Post
{
    public class UpdatePostRequest
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
