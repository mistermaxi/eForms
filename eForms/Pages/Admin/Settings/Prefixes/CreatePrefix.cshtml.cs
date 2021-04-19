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
    public class CreatePrefixModel : PageModel
    {
        public IEnumerable<PrefixModel> prefixes { get; set; }

        [BindProperty]
        public PrefixModel prefix { get; set; }


        IPrefixService prefixService;

        public CreatePrefixModel(IPrefixService _prefixService)
        {
            prefixService = _prefixService;
        }

        public async Task OnGet()
        {
            prefixes = await prefixService.GetAllPrefixes();

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await prefixService.CreatePrefix(prefix);
                return RedirectToPage("Prefixes");
            }
            else
            {
                return Page();
            }

        }
    }
}
