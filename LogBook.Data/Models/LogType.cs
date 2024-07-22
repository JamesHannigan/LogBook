using LogBook.Data.Enum;
using LogBook.DataLayer.Interfaces;
namespace LogBook.Data.Models
{
    public class LogType : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public string? Name { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        public TypeLevel Level { get; set; } = TypeLevel.Unassigned;
    }
}
