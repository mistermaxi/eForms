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

namespace eForms.Pages.Admin
{
    public class EditUserModel : PageModel
    {
        public IEnumerable<eForms.Services.Models.UsersModel> users { get; set; }
        public IEnumerable<eForms.Services.Models.UserRolesModel> userroles { get; set; }
        public IEnumerable<eForms.Services.Models.ADUserModel> adusers { get; set; }
        public IEnumerable<eForms.Services.Models.FormModel> forms { get; set; }

        [BindProperty]
        public eForms.Services.Models.UsersModel user { get; set; }

        [BindProperty]
        public eForms.Services.Models.UserRolesModel userrole { get; set; }

        [BindProperty]
        public eForms.Services.Models.ADUserModel aduser { get; set; }

        [BindProperty]
        public eForms.Services.Models.FormModel form { get; set; }

        [BindProperty]
        public string aduser_selected { get; set; }

        [BindProperty]
        public string role_selected { get; set; }

        [BindProperty]
        public int form_selected { get; set; }

        IUserService userService;
        IADSIService adsiService;
        IFormService formService;

        public EditUserModel(IUserService _userService, IADSIService _adsiService, IFormService _formService)
        {
            userService = _userService;
            adsiService = _adsiService;
            formService = _formService;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            //if (await authService.Check(Roles.Admin, 0) == false)
            //{
            //    return RedirectToPage("/Error", "Error", new { @Id = 401 });
            //}
            //else
            //{
            //    building = await buildingService.ReadAsync(id);
            //    return Page();
            //}
            adusers = await adsiService.GetAllUsers();
            forms = await formService.GetAllForms();

            user = await userService.ReadUserRoleAsync(id);

            form_selected = user.FormId;            
            aduser_selected = user.EmailAddress;

            return Page();

        }
        public async Task<IActionResult> OnPost()
        {
            //if (ModelState.IsValid)
            //{
            //    post.PostCountry = country_selected;
            //    await postService.UpdatePostAsync(post);
            //}
            //return RedirectToPage("Posts");

            //userrole.FormId = form_selected;
            await userService.UpdateAsync(user);
            return RedirectToPage("ManageUsers").WithSuccess("Info", "Succesfully updated!");
        }
    }
}
