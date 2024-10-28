namespace LogBook.BusinessLogic.DTO.API
{
    public class LogModelDTO
    {
        public required string APIKey { get; set; }
        public string? Description { get; set; }
        public double? Value { get; set; }
        public string? Path { get; set; }
        public int? LogTypeId { get; set; }
        public string? LogTypeName { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
    }
}
