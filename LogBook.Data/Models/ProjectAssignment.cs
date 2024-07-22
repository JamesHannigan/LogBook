using LogBook.Data.Enum;
using LogBook.DataLayer.Interfaces;
namespace LogBook.Data.Models
{
    public class ProjectAssignment : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        public string? AssigneeId { get; set; }
        public ApplicationUser? Assignee { get; set; }
        public string? InvitedById { get; set; }
        public ApplicationUser? InvitedBy { get; set; }
        public DateTime? InviteAccepted { get; set; }
        public ProjectRole RoleType { get; set; }
    }
}
