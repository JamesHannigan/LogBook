namespace LogBook.BusinessLogic.Interface.System
{
    public interface IAccountService
    {
        Task RegisterUser(string username, string firstName, string lastName, string emailAddress, string password);
        Task<bool> SignIn(string userNameOrEmail, string password, bool isPersistent);
        Task SignOut();
    }
}
