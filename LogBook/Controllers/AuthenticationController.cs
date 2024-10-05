using LogBook.BusinessLogic.Interface.System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LogBook.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAccountService _accountService;
        public AuthenticationController(IAccountService accountService) { _accountService = accountService; }
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<JsonResult> RegisterUser()
        {
            string userName = HttpContext.Request.Form["userName"];
            string emailAddress = HttpContext.Request.Form["emailAddress"];
            string firstName = HttpContext.Request.Form["firstName"];
            string lastName = HttpContext.Request.Form["lastName"];
            string password = HttpContext.Request.Form["password"];
            List<string> result = await _accountService.RegisterUser(userName, firstName, lastName, emailAddress, password);
            
            if(result.Count == 0) {
                bool signInSuccess = await _accountService.SignIn(userName, password, true);
            }
            //else
            //{
            //    //return Redirect("/Authentication");
            //}
            return Json(result);
        }

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
