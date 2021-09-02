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

namespace eForms.Pages.Main
{
    public class EditProfileModel : PageModel
    {
        public IEnumerable<UsersModel> profiles { get; set; }

        [BindProperty]
        public UsersModel profile { get; set; }

        IProfileService profileService;
        public EditProfileModel(IProfileService _profileService)
        {
            profileService = _profileService;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            if(id is null)
            {
                id = HttpContext.Session.GetString("auth");
            }
            profile = await profileService.ReadAsync(id);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await profileService.UpdateProfileAsync(profile);
            }
           // return RedirectToPage("Index");
            return RedirectToPage("EditProfile", new { id = HttpContext.Session.GetString("auth") }).WithSuccess("Info", "Succesfully updated!");
            //return RedirectToPage("EditProfile");
        }
    }
}
