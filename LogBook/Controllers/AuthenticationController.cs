using LogBook.BusinessLogic.Interface.System;
using Microsoft.AspNetCore.Mvc;

namespace LogBook.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAccountService _accountService;
        public AuthenticationController(IAccountService accountService) { _accountService = accountService; }
        public IActionResult Index() => View();
        public async Task RegisterUser(string userName, string firstName, string lastName, string emailAddress, string password) => await _accountService.RegisterUser(userName, firstName, lastName, emailAddress, password);

        [HttpPost]
        public async Task<IActionResult> SignIn()
        {
            string? userNameOrEmail = HttpContext.Request.Form["loginNameOrEmail"];
            string? password = HttpContext.Request.Form["loginPassword"];
            string? isPersistentString = HttpContext.Request.Form["loginIsPersistent"];
            bool isPersistent = !string.IsNullOrWhiteSpace(isPersistentString) ? (isPersistentString == "on" ? true : false) : false;
            bool signInSuccess = await _accountService.SignIn(userNameOrEmail, password, isPersistent);
            return signInSuccess ? Redirect("/") : Redirect("/Authentication");
        }

        public async Task<IActionResult> SignOut(){
            await _accountService.SignOut();
            return Redirect("/Authentication");
        }
    }
}
