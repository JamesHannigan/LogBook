namespace LogBook.Data.DTOs.Data
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public string? Name { get; set; }
        public DateTime Created { get; set; } 
        public int LogTypesCount { get; set; }
        public int LogsCount { get; set; }
        public int AssigneesCount { get; set; }
        public List<LogTypeDTO> LogTypes { get; set; } = new();
        public List<AssigneeDTO> Assignees { get; set; } = new();
    }
}
