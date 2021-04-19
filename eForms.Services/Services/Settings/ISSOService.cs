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
    public class ISSOService : IISSOService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public ISSOService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<tbl_rISSO> GetDbSet()
        {
            return context.tbl_rISSO;
        }

        public async Task<List<ISSOModel>> GetAllISSO()
        {

            List<ISSOModel> dto = mapper.Map<List<tbl_rISSO>, List<ISSOModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<tbl_rISSO> GetQueryable()
        {
            return context.tbl_rISSO;
        }
        public async Task<ISSOModel> ReadAsync(int id)
        {
            tbl_rISSO model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<ISSOModel>(model);
        }
        public async Task<int> CreateISSO(ISSOModel model)
        {
            tbl_rISSO isso = mapper.Map<tbl_rISSO>(model);
            context.tbl_rISSO.Add(isso);
            await context.SaveChangesAsync();
            return isso.Id;
        }
        public async Task UpdateISSOAsync(ISSOModel model)
        {
            context.tbl_rISSO.Update(mapper.Map<tbl_rISSO>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<ISSOModel>> SearchForISSOAsync(string search)
        {
            List<tbl_rISSO> isso = await context.tbl_rISSO
                .Where(x => x.Name.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<ISSOModel>>(isso);
        }
        public async Task DeleteISSO(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageISSO, id);
            context.tbl_rISSO.Remove(new tbl_rISSO() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
