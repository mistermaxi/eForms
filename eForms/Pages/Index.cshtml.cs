using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using eForms.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace eForms.Pages
{
    public class IndexModel : PageModel
    {
        public string auth { get; set; }
        
        IAuthService authService;
        IUserService userService;
        IEncryptDecryptService encryptService;

        [BindProperty]
        public eForms.Services.Models.UsersModel user { get; set; }

        public IndexModel(IAuthService _authService, IUserService _userService, IEncryptDecryptService _encryptService)
        {
            authService = _authService;
            userService = _userService;
            encryptService = _encryptService;
        }

        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        //public void OnGet()
        public async Task<IActionResult> OnGet()
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

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            string username = authService.GetUserWithoutDomain();
            HttpContext.Session.SetString("auth", username);

            user = await userService.ReadUserNameAsync(username);
            HttpContext.Session.SetString("authName", user.DisplayName);
            HttpContext.Session.SetString("authRole", user.Role);
            return Page();
        }
    }
}
