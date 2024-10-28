using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace LogBook.BusinessLogic.Interface.System
{
    public interface IAccountService
    {
        Task<List<string>> CreateUser(string username, string firstName, string lastName, string emailAddress, string password);
        Task<List<string>> RegisterUser(HttpRequest request);
        Task<bool> SignIn(string userNameOrEmail, string password, bool isPersistent);
        Task SignOut();
    }
}
