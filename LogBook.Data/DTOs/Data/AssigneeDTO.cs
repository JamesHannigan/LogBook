using LogBook.Data.Enum;

namespace LogBook.Data.DTOs.Data
{
    public class AssigneeDTO
    {
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? InviteAccepted { get; set; }
        public ProjectRole RoleType { get; set; }
        public string RoleName { get { return RoleType.ToString(); } }
    }
}
