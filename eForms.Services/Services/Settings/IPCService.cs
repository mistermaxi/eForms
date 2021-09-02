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
        private DbSet<IPC> GetDbSet()
        {
            return context.tbl_rIPCs;
        }

        public async Task<List<IPCModel>> GetAllIPC()
        {

            List<IPCModel> dto = mapper.Map<List<IPC>, List<IPCModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<IPC> GetQueryable()
        {
            return context.tbl_rIPCs;
        }
        public async Task<IPCModel> ReadAsync(int id)
        {
            IPC model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<IPCModel>(model);
        }
        public async Task<int> CreateIPC(IPCModel model)
        {
            IPC ipc = mapper.Map<IPC>(model);
            context.tbl_rIPCs.Add(ipc);
            await context.SaveChangesAsync();
            return ipc.Id;
        }
        public async Task UpdateIPCAsync(IPCModel model)
        {
            context.tbl_rIPCs.Update(mapper.Map<IPC>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<IPCModel>> SearchForIPCAsync(string search)
        {
            List<IPC> ipc = await context.tbl_rIPCs
                .Where(x => x.Name.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<IPCModel>>(ipc);
        }
        public async Task DeleteIPC(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageIPC, id);
            context.tbl_rIPCs.Remove(new IPC() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
