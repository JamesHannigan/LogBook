using LogBook.DataLayer.Interfaces;
namespace LogBook.Data.Models
{
    public class Activity : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public int? LogTypeId { get; set; }
        public LogType? LogType { get; set; }
        public string? Description { get; set; }
        //public double? Figure { get; set; }
        public string? Path { get; set; }
        public int? UserID { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public DateTime? Timestamp { get; set; }
        public ErrorLog? ErrorLog { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        public int? TenantId { get; set; }
        public Tenant? Tenant { get; set; }
    }
}
