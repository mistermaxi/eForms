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
    public class IPCService : IIPCService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public IPCService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<tbl_rIPC> GetDbSet()
        {
            return context.tbl_rIPCs;
        }

        public async Task<List<IPCModel>> GetAllIPC()
        {

            List<IPCModel> dto = mapper.Map<List<tbl_rIPC>, List<IPCModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<tbl_rIPC> GetQueryable()
        {
            return context.tbl_rIPCs;
        }
        public async Task<IPCModel> ReadAsync(int id)
        {
            tbl_rIPC model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<IPCModel>(model);
        }
        public async Task<int> CreateIPC(IPCModel model)
        {
            tbl_rIPC ipc = mapper.Map<tbl_rIPC>(model);
            context.tbl_rIPCs.Add(ipc);
            await context.SaveChangesAsync();
            return ipc.Id;
        }
        public async Task UpdateIPCAsync(IPCModel model)
        {
            context.tbl_rIPCs.Update(mapper.Map<tbl_rIPC>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<IPCModel>> SearchForIPCAsync(string search)
        {
            List<tbl_rIPC> ipc = await context.tbl_rIPCs
                .Where(x => x.Name.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<IPCModel>>(ipc);
        }
        public async Task DeleteIPC(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageIPC, id);
            context.tbl_rIPCs.Remove(new tbl_rIPC() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
