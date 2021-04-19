using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;

namespace eForms.Pages.Admin
{
    public class CreateISOModel : PageModel
    {
        public IEnumerable<eForms.Services.Models.ISOModel> isos { get; set; }

        [BindProperty]
        public eForms.Services.Models.ISOModel iso { get; set; }


        IISOService isoService;

        public CreateISOModel(IISOService _isoService)
        {
            isoService = _isoService;
        }

        public async Task OnGet()
        {
            isos = await isoService.GetAllISO();

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await isoService.CreateISO(iso);
                return RedirectToPage("ISO");
            }
            else
            {
                return Page();
            }

        }
    }
}
