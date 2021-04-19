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
    public class UserRoleService : IUserRoleService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public UserRoleService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }

        private DbSet<tbl_eForm_UserRole> GetDbSet()
        {
            return context.tbl_eForm_UserRoles;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<tbl_eForm_UserRole> GetQueryable()
        {
            return context.tbl_eForm_UserRoles;
        }
        public async Task<List<UserRolesModel>> GetAllUserRoles()
        {

            List<UserRolesModel> dto = mapper.Map<List<tbl_eForm_UserRole>, List<UserRolesModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task UpdateAsync(UserRolesModel model)
        {
            context.tbl_eForm_UserRoles.Update(mapper.Map<tbl_eForm_UserRole>(model));
            await context.SaveChangesAsync();
        }
        public async Task<UserRolesModel> ReadAsync(int id)
        {
            tbl_eForm_UserRole model = await context.tbl_eForm_UserRoles
                //.Where(x => x.Id == id)
                //Where(x => x.EmailAddress == mail)
                .Where(x => x.UserId == id)
                //.Include(x => x.Identity)
                .SingleOrDefaultAsync();
            return mapper.Map<UserRolesModel>(model);
        }

    }
}
