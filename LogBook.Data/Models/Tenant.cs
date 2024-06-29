using LogBook.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.Data.Models
{
    public class Tenant : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public string? Reference { get; set; }
        public string? Name { get; set; }
        public Project? Project { get; set; }
    }
}
