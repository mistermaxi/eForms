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
    public class ClassNetService : IClassNetService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        private IAuthService authService;
        public ClassNetService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer, IAuthService _authService)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            authService = _authService;
        }
        private DbSet<ClassNetReq> GetDbSet()
        {
            return context.tbl_ClassNetReq;
        }
        public async Task<List<ClassNetModel>> GetAllRequest()
        {
            List<ClassNetModel> dto = mapper.Map<List<ClassNetReq>, List<ClassNetModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<ClassNetReq> GetQueryable()
        {
            return context.tbl_ClassNetReq;
        }
        public async Task<ClassNetModel> ReadAsync(int id)
        {
            ClassNetReq model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<ClassNetModel>(model);
        }
        public async Task<int> CreateNewRequest(ClassNetModel model)
        {
            ClassNetReq request = mapper.Map<ClassNetReq>(model);
            context.tbl_ClassNetReq.Add(request);
            await context.SaveChangesAsync();
            return request.Id;
        }
        public async Task UpdateRequestAsync(ClassNetModel model)
        {
            context.tbl_ClassNetReq.Update(mapper.Map<ClassNetReq>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<ClassNetModel>> SearchForRequestsAsync(string search)
        {
            List<ClassNetReq> requests = await context.tbl_ClassNetReq
                .Where(x => x.LastName.Contains(search) || x.FirstName.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<ClassNetModel>>(requests);
        }
        public async Task DeleteRequest(int id)
        {
            context.tbl_ClassNetReq.Remove(new ClassNetReq() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
