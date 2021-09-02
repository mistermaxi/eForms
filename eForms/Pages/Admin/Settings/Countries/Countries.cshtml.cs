using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using eForms.Domain.Enums;
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
        IAuthService authService;
        public CountriesModel(ICountryService _countryService, IAuthService _authService)
        {
            countryService = _countryService;
            authService = _authService;
        }
        public async Task OnGet()
        {
            countries = await countryService.GetAllCountries();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            if (await authService.Check(Roles.Admin, 0) == false)
            {
                return RedirectToPage("/Error", "Error", new { @Id = 401 });
            }
            else
            {
                await countryService.DeleteCountry(id);
                return RedirectToPage("Countries");
            }
            
        }
    }
}
