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
    public class EmpTypeService : IEmpTypeService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public EmpTypeService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<tbl_rEmployeeType> GetDbSet()
        {
            return context.tbl_rEmployeeTypes;
        }

        public async Task<List<EmpTypeModel>> GetAllEmpTypes()
        {

            List<EmpTypeModel> dto = mapper.Map<List<tbl_rEmployeeType>, List<EmpTypeModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<tbl_rEmployeeType> GetQueryable()
        {
            return context.tbl_rEmployeeTypes;
        }
        public async Task<EmpTypeModel> ReadAsync(int id)
        {
            tbl_rEmployeeType model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<EmpTypeModel>(model);
        }
        private async Task<tbl_rEmployeeType> EnsureExists(tbl_rEmployeeType emptypes, string emptype)
        {
            if (emptypes != null) return emptypes;
            emptypes = new tbl_rEmployeeType() { EmpType = emptype };
            context.tbl_rEmployeeTypes.Add(emptypes);
            await context.SaveChangesAsync();
            context.Entry(emptypes).State = EntityState.Detached;
            return emptypes;
        }
        public async Task<int> CreateEmpType(EmpTypeModel model)
        {
            tbl_rEmployeeType emptype = mapper.Map<tbl_rEmployeeType>(model);
            context.tbl_rEmployeeTypes.Add(emptype);
            await context.SaveChangesAsync();
            return emptype.Id;
        }
        public async Task UpdateEmpTypeAsync(EmpTypeModel model)
        {
            context.tbl_rEmployeeTypes.Update(mapper.Map<tbl_rEmployeeType>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<EmpTypeModel>> SearchForEmpTypesAsync(string search)
        {
            List<tbl_rEmployeeType> emptypes = await context.tbl_rEmployeeTypes
                .Where(x => x.EmpType.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<EmpTypeModel>>(emptypes);
        }
        public async Task DeleteEmpType(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageEmpTypes, id);
            context.tbl_rEmployeeTypes.Remove(new tbl_rEmployeeType() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
