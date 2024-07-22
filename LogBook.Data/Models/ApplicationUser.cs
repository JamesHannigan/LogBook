using Microsoft.AspNetCore.Identity;

namespace LogBook.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public DateTime? Registered { get; set; }
    }
}
