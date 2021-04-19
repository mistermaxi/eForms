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
    public class CountriesModel : PageModel
    {
        public IEnumerable<CountryModel> countries { get; set; }

        ICountryService countryService;

        public CountriesModel(ICountryService _countryService)
        {
            countryService = _countryService;
        }
        public async Task OnGet()
        {
            countries = await countryService.GetAllCountries();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await countryService.DeleteCountry(id);
            return RedirectToPage("Countries");
        }
    }
}
