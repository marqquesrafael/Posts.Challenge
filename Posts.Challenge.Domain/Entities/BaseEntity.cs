namespace Posts.Challenge.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity() => Active = true;

        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool Active { get; set; }
    }
}
