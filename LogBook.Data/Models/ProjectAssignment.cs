using LogBook.Data.Enum;
using LogBook.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.Data.Models
{
    public class ProjectAssignment : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public Project? Project { get; set; }
        //public ApplicationUser? Assignee { get; set; }
        //public ApplicationUser? InvitedBy { get; set; }
        public DateTime? InviteAccepted { get; set; }
        public ProjectRole RoleType { get; set; }
    }
}
