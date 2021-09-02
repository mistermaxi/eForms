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

namespace eForms.Services.Services
{
    public class FormService : IFormService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public FormService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<Forms> GetDbSet()
        {
            return context.tbl_rForms;
        }

        public async Task<List<FormModel>> GetAllForms()
        {

            List<FormModel> dto = mapper.Map<List<Forms>, List<FormModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<Forms> GetQueryable()
        {
            return context.tbl_rForms;
        }
        public async Task<FormModel> ReadAsync(int id)
        {
            Forms model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<FormModel>(model);
        }
        public async Task<int> CreateForm(FormModel model)
        {
            Forms building = mapper.Map<Forms>(model);
            context.tbl_rForms.Add(building);
            await context.SaveChangesAsync();
            return building.Id;
        }
        public async Task UpdateFormAsync(FormModel model)
        {
            context.tbl_rForms.Update(mapper.Map<Forms>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<FormModel>> SearchForFormsAsync(string search)
        {
            List<Forms> agencies = await context.tbl_rForms
                .Where(x => x.formtitle.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<FormModel>>(agencies);
        }
        public async Task DeleteForm(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageForms, id);
            context.tbl_rForms.Remove(new Forms() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
