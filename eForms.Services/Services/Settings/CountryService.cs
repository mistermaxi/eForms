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
        private DbSet<tbl_rCountry> GetDbSet()
        {
            return context.tbl_rCountries;
        }

        public async Task<List<CountryModel>> GetAllCountries()
        {

            List<CountryModel> dto = mapper.Map<List<tbl_rCountry>, List<CountryModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<tbl_rCountry> GetQueryable()
        {
            return context.tbl_rCountries;
        }
        public async Task<CountryModel> ReadAsync(int id)
        {
            tbl_rCountry model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<CountryModel>(model);
        }
        public async Task<int> CreateCountry(CountryModel model)
        {
            tbl_rCountry country = mapper.Map<tbl_rCountry>(model);
            context.tbl_rCountries.Add(country);
            await context.SaveChangesAsync();
            return country.Id;
        }
        public async Task UpdateCountryAsync(CountryModel model)
        {
            context.tbl_rCountries.Update(mapper.Map<tbl_rCountry>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<CountryModel>> SearchForCountriesAsync(string search)
        {
            List<tbl_rCountry> countries = await context.tbl_rCountries
                .Where(x => x.CountryName.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<CountryModel>>(countries);
        }
        public async Task DeleteCountry(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageCountries, id);
            context.tbl_rCountries.Remove(new tbl_rCountry() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
