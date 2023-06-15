namespace APIStandarts.Core.Domain
{
    public abstract class RootEntity : IRootEntity
    {
        public string Id { get; init; } // Nesnenin sadece contructor üzerinden Id set edilecek
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
