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
    public class ISSOModel : PageModel
    {
        public IEnumerable<eForms.Services.Models.ISSOModel> issos { get; set; }

        IISSOService issoService;

        public ISSOModel(IISSOService _issoService)
        {
            issoService = _issoService;
        }
        public async Task OnGet()
        {
            issos = await issoService.GetAllISSO();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await issoService.DeleteISSO(id);
            return RedirectToPage("ISSO");
        }
    }
}
