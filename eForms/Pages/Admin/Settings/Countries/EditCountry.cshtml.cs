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
    public class EditCountryModel : PageModel
    {
        public IEnumerable<CountryModel> countries { get; set; }

        [BindProperty]
        public CountryModel country { get; set; }

        ICountryService countryService;

        public EditCountryModel(ICountryService _countryService)
        {
            countryService = _countryService;
        }

        public async Task OnGet(int id)
        {
            country = await countryService.ReadAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await countryService.UpdateCountryAsync(country);
            }
            return RedirectToPage("Countries");

        }
    }
}
