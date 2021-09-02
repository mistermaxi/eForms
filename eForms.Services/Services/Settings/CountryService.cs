using AutoMapper;
using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public class CountryService : ICountryService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        //private IAuthorizationService authorizationService;

        public CountryService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<Country> GetDbSet()
        {
            return context.tbl_rCountries;
        }

        public async Task<List<CountryModel>> GetAllCountries()
        {

            List<CountryModel> dto = mapper.Map<List<Country>, List<CountryModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<Country> GetQueryable()
        {
            return context.tbl_rCountries;
        }
        public async Task<CountryModel> ReadAsync(int id)
        {
            Country model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<CountryModel>(model);
        }
        public async Task<int> CreateCountry(CountryModel model)
        {
            Country country = mapper.Map<Country>(model);
            context.tbl_rCountries.Add(country);
            await context.SaveChangesAsync();
            return country.Id;
        }
        public async Task UpdateCountryAsync(CountryModel model)
        {
            context.tbl_rCountries.Update(mapper.Map<Country>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<CountryModel>> SearchForCountriesAsync(string search)
        {
            List<Country> countries = await context.tbl_rCountries
                .Where(x => x.CountryName.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<CountryModel>>(countries);
        }
        public async Task DeleteCountry(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageCountries, id);
            context.tbl_rCountries.Remove(new Country() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
