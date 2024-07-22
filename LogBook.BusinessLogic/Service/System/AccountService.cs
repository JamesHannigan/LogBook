using LogBook.BusinessLogic.Interface.System;
using LogBook.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace LogBook.BusinessLogic.Service.System
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task RegisterUser(string username, string firstName, string lastName, string emailAddress, string password)
        {
            ApplicationUser user = new ApplicationUser { 
                UserName = username, 
                FirstName = firstName, 
                LastName = lastName, 
                Email = emailAddress, 
                Registered = DateTime.UtcNow 
            };
            try
            {
                IdentityResult result = await _userManager.CreateAsync(user, password);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task<bool> SignIn(string userNameOrEmail, string password, bool isPersistent)
        {
            SignInResult result = new();
            ApplicationUser? user;
            user = await _userManager.FindByNameAsync(userNameOrEmail);
            if(user == null) user = await _userManager.FindByEmailAsync(userNameOrEmail);
            if (user != null)
            {
                result = await _signInManager.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure: false);
            }
            return result.Succeeded;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
