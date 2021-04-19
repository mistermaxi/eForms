using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public interface ICountryService
    {
        Task<int> CountAsync();
        Task<List<CountryModel>> GetAllCountries();
        Task<CountryModel> ReadAsync(int id);
        Task<int> CreateCountry(CountryModel model);
        public Task UpdateCountryAsync(CountryModel model);
        Task<List<CountryModel>> SearchForCountriesAsync(string search);
        Task DeleteCountry(int Id);
    }
}
