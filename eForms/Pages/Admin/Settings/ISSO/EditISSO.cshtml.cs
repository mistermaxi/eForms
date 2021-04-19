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

namespace eForms.Pages.Admin
{
    public class EditISSOModel : PageModel
    {
        public IEnumerable<eForms.Services.Models.ISSOModel> issos { get; set; }

        [BindProperty]
        public eForms.Services.Models.ISSOModel isso { get; set; }

        IISSOService issoService;

        public EditISSOModel(IISSOService _issoService)
        {
            issoService = _issoService;
        }

        public async Task OnGet(int id)
        {
            isso = await issoService.ReadAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await issoService.UpdateISSOAsync(isso);
            }
            return RedirectToPage("ISSO");

        }
    }
}
