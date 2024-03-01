namespace HDISigorta.Domain.Entities.Common
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Guid? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? DeletedUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
