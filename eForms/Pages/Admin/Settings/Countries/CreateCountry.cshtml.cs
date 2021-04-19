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
    public class CreateCountryModel : PageModel
    {
        public IEnumerable<CountryModel> countries { get; set; }

        [BindProperty]
        public CountryModel country { get; set; }


        ICountryService countryService;

        public CreateCountryModel(ICountryService _countryService)
        {
            countryService = _countryService;
        }

        public async Task OnGet()
        {
            countries = await countryService.GetAllCountries();

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await countryService.CreateCountry(country);
                return RedirectToPage("Countries");
            }
            else
            {
                return Page();
            }

        }
    }
}
