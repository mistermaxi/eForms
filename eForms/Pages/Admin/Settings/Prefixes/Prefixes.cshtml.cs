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
    public class PrefixesModel : PageModel
    {
        public IEnumerable<PrefixModel> prefixes { get; set; }

        IPrefixService prefixService;

        public PrefixesModel(IPrefixService _prefixService)
        {
            prefixService = _prefixService;
        }
        public async Task OnGet()
        {
            prefixes = await prefixService.GetAllPrefixes();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await prefixService.DeletePrefix(id);
            return RedirectToPage("Prefixes");
        }
    }
}
