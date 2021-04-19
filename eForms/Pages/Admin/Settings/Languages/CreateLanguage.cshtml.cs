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
    public class CreateLanguageModel : PageModel
    {
        public IEnumerable<LanguageModel> languages { get; set; }

        [BindProperty]
        public LanguageModel language { get; set; }


        ILanguageService languageService;

        public CreateLanguageModel(ILanguageService _languageService)
        {
            languageService = _languageService;
        }

        public async Task OnGet()
        {
            languages = await languageService.GetAllLanguages();

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await languageService.CreateLanguage(language);
                return RedirectToPage("Languages");
            }
            else
            {
                return Page();
            }

        }
    }
}
