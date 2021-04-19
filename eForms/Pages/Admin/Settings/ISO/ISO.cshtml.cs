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
    public class ISOModel : PageModel
    {
        public IEnumerable<eForms.Services.Models.ISOModel> isos { get; set; }

        IISOService isoService;

        public ISOModel(IISOService _isoService)
        {
            isoService = _isoService;
        }
        public async Task OnGet()
        {
            isos = await isoService.GetAllISO();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await isoService.DeleteISO(id);
            return RedirectToPage("ISO");
        }
    }
}
