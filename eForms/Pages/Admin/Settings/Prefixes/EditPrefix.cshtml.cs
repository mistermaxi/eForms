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
    public class EditPrefixModel : PageModel
    {
        public IEnumerable<PrefixModel> prefixes { get; set; }

        [BindProperty]
        public PrefixModel prefix { get; set; }


        IPrefixService prefixService;

        public EditPrefixModel(IPrefixService _prefixService)
        {
            prefixService = _prefixService;
        }

        public async Task OnGet(int id)
        {
            prefix = await prefixService.ReadAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await prefixService.UpdatePrefixAsync(prefix);
            }
            return RedirectToPage("Prefixes");

        }
    }
}
