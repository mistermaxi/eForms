using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eForms.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace eForms.Pages
{
    public class LoginModel : PageModel
    {
        IAuthService authService;
        IUserService userService;
        IEncryptDecryptService encryptService;

        [BindProperty]
        public eForms.Services.Models.UsersModel user { get; set; }

        public LoginModel(IAuthService _authService, IUserService _userService, IEncryptDecryptService _encryptService)
        {
            authService = _authService;
            userService = _userService;
            encryptService = _encryptService;
        }

        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPost()
        {
            string username = authService.GetUserWithoutDomain();
            HttpContext.Session.SetString("auth", username);

            user = await userService.ReadUserNameAsync(username);
            HttpContext.Session.SetString("authName", user.DisplayName);
            HttpContext.Session.SetString("authRole", user.Role);

            string encryptedData = encryptService.EncryptData("BangkokSQL11\\SQLENT");
            string decryptedData = encryptService.DecryptData(encryptedData);

            string encryptedString = encryptService.EncryptString("BangkokSQL11\\SQLENT");
            string decryptedString = encryptService.DecryptString(encryptedString);

            string encrypted = encryptService.Encrypt("BangkokSQL11\\SQLENT");
            string decrypted = encryptService.Decrypt(encrypted);


            bool _dinGroups = authService.IsInGroup("bnkdin\\bnk isc");
            bool _opennetGroups = authService.IsInGroup("eap\\bnk isc");

            ViewData["DinResult"] = " DinResult : " + _dinGroups;
            ViewData["OpenNetResult"] = " OpenNetResult : " + _opennetGroups;

            return Page();
        }
    }
}
