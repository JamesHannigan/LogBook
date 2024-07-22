using LogBook.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.Data.Models
{
    public class Project : IBaseEntity
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; } = Guid.NewGuid();
        public DateTime? Deleted { get; set; }
        public string? Name { get; set; }
        public string? ApiKey { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
