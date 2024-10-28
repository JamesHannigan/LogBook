using LogBook.Data.Enum;
using LogBook.DataLayer.Interfaces;

namespace LogBook.Data.Models
{
    public class DashboardElement : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public Project? Project { get; set; }
        public List<LogType>? LogTypes { get; set; }
        public List<TypeLevel>? LogTypeLevels { get; set; }
        public string? Title { get; set; }
        public DashboardRange DateRange { get; set; } // NEW ENUM
        public DashboardType DashboardType { get; set; } // NEW ENUM
    }
}