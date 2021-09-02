using AutoMapper;
using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
//using eForms.Services.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public class SectionService : ISectionService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public SectionService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<Sections> GetDbSet()
        {
            return context.tbl_rSections;
        }

        public async Task<List<SectionModel>> GetAllSections()
        {

            List<SectionModel> dto = mapper.Map<List<Sections>, List<SectionModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<Sections> GetQueryable()
        {
            return context.tbl_rSections;
        }
        public async Task<SectionModel> ReadAsync(int id)
        {
            Sections model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<SectionModel>(model);
        }
        public async Task<int> CreateSection(SectionModel model)
        {
            Sections section = mapper.Map<Sections>(model);
            context.tbl_rSections.Add(section);
            await context.SaveChangesAsync();
            return section.Id;
        }
        public async Task UpdateSectionAsync(SectionModel model)
        {
            context.tbl_rSections.Update(mapper.Map<Sections>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<SectionModel>> SearchForSectionsAsync(string search)
        {
            List<Sections> sections = await context.tbl_rSections
                .Where(x => x.sectionname.Contains(search) || x.sectionabbr.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<SectionModel>>(sections);
        }

        [Authorize(Roles = "Admin,Manager")]
        //[Authorize(Roles = DemoSimpleRoleProvider.ADMIN)]
        public async Task DeleteSection(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageMilRank, id);
            context.tbl_rSections.Remove(new Sections() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
