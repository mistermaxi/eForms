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
    public class CreateISSOModel : PageModel
    {
        public IEnumerable<eForms.Services.Models.ISSOModel> issos { get; set; }

        [BindProperty]
        public eForms.Services.Models.ISSOModel isso { get; set; }


        IISSOService issoService;

        public CreateISSOModel(IISSOService _issoService)
        {
            issoService = _issoService;
        }

        public async Task OnGet()
        {
            issos = await issoService.GetAllISSO();

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await issoService.CreateISSO(isso);
                return RedirectToPage("ISSO");
            }
            else
            {
                return Page();
            }

        }
    }
}
