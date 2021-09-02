using AutoMapper;
using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public class OpenNetService : IOpenNetService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        private IAuthService authService;
        public OpenNetService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer, IAuthService _authService)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            authService = _authService;
        }
        private DbSet<OpenNetReq> GetDbSet()
        {
            return context.tbl_OpenNetReq;
        }
        public async Task<List<OpenNetModel>> GetAllRequest()
        {

            List<OpenNetModel> dto = mapper.Map<List<OpenNetReq>, List<OpenNetModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<OpenNetReq> GetQueryable()
        {
            return context.tbl_OpenNetReq;
        }
        public async Task<OpenNetModel> ReadAsync(int id)
        {
            OpenNetReq model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<OpenNetModel>(model);
        }
        public async Task<int> CreateNewRequest(OpenNetModel model)
        {
            OpenNetReq request = mapper.Map<OpenNetReq>(model);
            context.tbl_OpenNetReq.Add(request);
            await context.SaveChangesAsync();
            return request.Id;
        }
        public async Task UpdateRequestAsync(OpenNetModel model)
        {
            context.tbl_OpenNetReq.Update(mapper.Map<OpenNetReq>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<OpenNetModel>> SearchForRequestsAsync(string search)
        {
            List<OpenNetReq> requests = await context.tbl_OpenNetReq
                .Where(x => x.LastName.Contains(search) || x.FirstName.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<OpenNetModel>>(requests);
        }
        public async Task DeleteRequest(int id)
        {
            context.tbl_OpenNetReq.Remove(new OpenNetReq() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
