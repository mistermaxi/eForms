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
    public class EditLanguageModel : PageModel
    {
        public IEnumerable<LanguageModel> languages { get; set; }

        [BindProperty]
        public LanguageModel language { get; set; }

        ILanguageService languageService;

        public EditLanguageModel(ILanguageService _languageService)
        {
            languageService = _languageService;
        }

        public async Task OnGet(int id)
        {
            language = await languageService.ReadAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await languageService.UpdateLanguageAsync(language);
            }
            return RedirectToPage("Languages");

        }
    }
}
