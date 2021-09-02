using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using eForms.Domain.Enums;

namespace eForms.Pages.Admin
{
    public class CreateUserModel : PageModel
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

        public CreateUserModel(IUserService _userService, IADSIService _adsiService, IFormService _formService)
        {
            userService = _userService;
            adsiService = _adsiService;
            formService = _formService;
        }

        public async Task OnGet()
        {
            adusers = await adsiService.GetAllUsers();
            forms = await formService.GetAllForms();
        }
        
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                user.EmailAddress = aduser_selected;
                aduser = await adsiService.ReadAsync(user.EmailAddress);
                user.Username = aduser.samaccountname;
                user.DisplayName = aduser.displayname;
                user.OfficePhone = aduser.telephoneNumber;
                userrole.FormId = form_selected;
                userrole.Role = role_selected;

                if (await userService.CreateUserRole(user, userrole, aduser_selected, form_selected) != 0)
                {
                    //return RedirectToPage("ManageUsers");
                    return RedirectToPage("ManageUsers").WithSuccess("Info", "Succesfully Saved!");                    
                }
                else
                {
                    //return RedirectToPage("/Error", "Error", new { @Id = 1 });
                    return RedirectToPage("ManageUsers").WithDanger("Error", "User already assigned to this role and form!");
                }
                    

            }
            else
            {
                return Page();
                
            }

        }

        

    }
}
