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
    public class LanguagesModel : PageModel
    {
        public IEnumerable<LanguageModel> languages { get; set; }

        ILanguageService langService;

        public LanguagesModel(ILanguageService _langService)
        {
            langService = _langService;
        }
        public async Task OnGet()
        {
            languages = await langService.GetAllLanguages();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await langService.DeleteLanguage(id);
            return RedirectToPage("Languages");
        }
    }
}
