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
        public IEnumerable<UserRolesModel> userroles { get; set; }

        IUserService userService;
        IUserRoleService userroleService;

        public ManageUsersModel(IUserService _userService, IUserRoleService _userroleService)
        {
            userService = _userService;
            userroleService = _userroleService;
        }
        public async Task OnGet()
        {
            users = await userService.GetAllUsers();
        }

    }
}
