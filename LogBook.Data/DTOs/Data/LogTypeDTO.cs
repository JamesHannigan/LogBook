using LogBook.Data.Enum;

namespace LogBook.Data.DTOs.Data
{
    public class LogTypeDTO
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string? Name { get; set; }
        public TypeLevel Level { get; set; }
    }
}
