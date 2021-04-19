using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eForms.Pages.Admin
{
    public class ManageUsersModel : PageModel
    {
        public IEnumerable<UsersModel> users { get; set; }

        IUserService userService;

        public ManageUsersModel(IUserService _userService)
        {
            userService = _userService;
        }
        public async Task OnGet()
        {
            users = await userService.GetAllUsers();
        }

    }
}
