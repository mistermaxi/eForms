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
using Microsoft.AspNetCore.Http;

namespace eForms.Pages.Admin
{
    public class EditISOModel : PageModel
    {
        public IEnumerable<eForms.Services.Models.ISOModel> isos { get; set; }

        [BindProperty]
        public eForms.Services.Models.ISOModel iso { get; set; }

        IISOService isoService;

        public EditISOModel(IISOService _isoService)
        {
            isoService = _isoService;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            //string sessionrole = HttpContext.Session.GetString("authRole").ToString().Trim();
            //if (sessionrole == "Admin")
            //{
            //    iso = await isoService.ReadAsync(id);
            //    return Page();
            //}
            //else
            //{
            //    return RedirectToPage("/Error", "Error", new { @Id = 401 });
            //}                
            iso = await isoService.ReadAsync(id);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await isoService.UpdateISOAsync(iso);
            }
            return RedirectToPage("ISO");

        }
    }
}
