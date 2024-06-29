namespace LogBook.DataLayer.Interfaces
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime? Deleted { get; set; }
        DateTime Created { get; set; }
    }
}