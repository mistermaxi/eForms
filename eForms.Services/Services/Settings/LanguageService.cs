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
    public class LanguageService : ILanguageService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public LanguageService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<Languages> GetDbSet()
        {
            return context.tbl_rLanguages;
        }

        public async Task<List<LanguageModel>> GetAllLanguages()
        {

            List<LanguageModel> dto = mapper.Map<List<Languages>, List<LanguageModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<Languages> GetQueryable()
        {
            return context.tbl_rLanguages;
        }
        public async Task<LanguageModel> ReadAsync(int id)
        {
            Languages model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<LanguageModel>(model);
        }
        public async Task<int> CreateLanguage(LanguageModel model)
        {
            Languages language = mapper.Map<Languages>(model);
            context.tbl_rLanguages.Add(language);
            await context.SaveChangesAsync();
            return language.Id;
        }
        public async Task UpdateLanguageAsync(LanguageModel model)
        {
            context.tbl_rLanguages.Update(mapper.Map<Languages>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<LanguageModel>> SearchForLanguagesAsync(string search)
        {
            List<Languages> languages = await context.tbl_rLanguages
                .Where(x => x.LangDesc.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<LanguageModel>>(languages);
        }
        public async Task DeleteLanguage(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageISSO, id);
            context.tbl_rLanguages.Remove(new Languages() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
