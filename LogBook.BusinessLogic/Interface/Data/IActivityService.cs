namespace LogBook.BusinessLogic.Interface.Data
{
    public interface IActivityService
    {
        string GetActivitiesAsTableRows(string? logTypesString);
        Task LogActivity(int? type, string? description, int? userId, string? userName, string? userEmail, string? path);
        Task LogError(int? type, string? description, int? userId, string? userName, string? userEmail, string? path);
    }
}
