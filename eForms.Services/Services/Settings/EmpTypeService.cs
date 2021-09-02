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
        private DbSet<EmployeeType> GetDbSet()
        {
            return context.tbl_rEmployeeTypes;
        }

        public async Task<List<EmpTypeModel>> GetAllEmpTypes()
        {

            List<EmpTypeModel> dto = mapper.Map<List<EmployeeType>, List<EmpTypeModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<EmployeeType> GetQueryable()
        {
            return context.tbl_rEmployeeTypes;
        }
        public async Task<EmpTypeModel> ReadAsync(int id)
        {
            EmployeeType model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<EmpTypeModel>(model);
        }
        private async Task<EmployeeType> EnsureExists(EmployeeType emptypes, string emptype)
        {
            if (emptypes != null) return emptypes;
            emptypes = new EmployeeType() { EmpType = emptype };
            context.tbl_rEmployeeTypes.Add(emptypes);
            await context.SaveChangesAsync();
            context.Entry(emptypes).State = EntityState.Detached;
            return emptypes;
        }
        public async Task<int> CreateEmpType(EmpTypeModel model)
        {
            EmployeeType emptype = mapper.Map<EmployeeType>(model);
            context.tbl_rEmployeeTypes.Add(emptype);
            await context.SaveChangesAsync();
            return emptype.Id;
        }
        public async Task UpdateEmpTypeAsync(EmpTypeModel model)
        {
            context.tbl_rEmployeeTypes.Update(mapper.Map<EmployeeType>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<EmpTypeModel>> SearchForEmpTypesAsync(string search)
        {
            List<EmployeeType> emptypes = await context.tbl_rEmployeeTypes
                .Where(x => x.EmpType.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<EmpTypeModel>>(emptypes);
        }
        public async Task DeleteEmpType(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageEmpTypes, id);
            context.tbl_rEmployeeTypes.Remove(new EmployeeType() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
