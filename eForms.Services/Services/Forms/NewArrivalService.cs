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
    public class NewArrivalService : INewArrivalService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public NewArrivalService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<NewArrvEMP> GetDbSet()
        {
            return context.tbl_NewArrvEMP;
        }
        public async Task<List<NewArrvEMPModel>> GetAllNewArrival()
        {

            List<NewArrvEMPModel> dto = mapper.Map<List<NewArrvEMP>, List<NewArrvEMPModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<NewArrvEMP> GetQueryable()
        {
            return context.tbl_NewArrvEMP;
        }
        public async Task<NewArrvEMPModel> ReadAsync(int id)
        {
            NewArrvEMP model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<NewArrvEMPModel>(model);
        }
        public async Task<int> CreateNewArrival(NewArrvEMPModel model)
        {
            NewArrvEMP newarrival = mapper.Map<NewArrvEMP>(model);
            context.tbl_NewArrvEMP.Add(newarrival);
            await context.SaveChangesAsync();
            return newarrival.Id;
        }
        public async Task UpdateNewArrivalAsync(NewArrvEMPModel model)
        {
            context.tbl_NewArrvEMP.Update(mapper.Map<NewArrvEMP>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<NewArrvEMPModel>> SearchForNewArrivalsAsync(string search)
        {
            List<NewArrvEMP> newarrivals = await context.tbl_NewArrvEMP
                .Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search))
                //.Where(x => x.FirstName.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<NewArrvEMPModel>>(newarrivals);
        }
        public async Task DeleteNewArrival(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageForms, id);
            context.tbl_NewArrvEMP.Remove(new NewArrvEMP() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
