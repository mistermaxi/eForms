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
    public class ISOService : IISOService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public ISOService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<tbl_rISO> GetDbSet()
        {
            return context.tbl_rISO;
        }

        public async Task<List<ISOModel>> GetAllISO()
        {

            List<ISOModel> dto = mapper.Map<List<tbl_rISO>, List<ISOModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<tbl_rISO> GetQueryable()
        {
            return context.tbl_rISO;
        }
        public async Task<ISOModel> ReadAsync(int id)
        {
            tbl_rISO model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<ISOModel>(model);
        }
        public async Task<int> CreateISO(ISOModel model)
        {
            tbl_rISO iso = mapper.Map<tbl_rISO>(model);
            context.tbl_rISO.Add(iso);
            await context.SaveChangesAsync();
            return iso.Id;
        }
        public async Task UpdateISOAsync(ISOModel model)
        {
            context.tbl_rISO.Update(mapper.Map<tbl_rISO>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<ISOModel>> SearchForISOAsync(string search)
        {
            List<tbl_rISO> ipc = await context.tbl_rISO
                .Where(x => x.Name.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<ISOModel>>(ipc);
        }
        public async Task DeleteISO(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageIPC, id);
            context.tbl_rISO.Remove(new tbl_rISO() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
