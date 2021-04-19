using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public interface IUserRoleService
    {
        Task<List<UserRolesModel>> GetAllUserRoles();
        //public Task<int> GetRoleId(string email);
        //public Task<int> GetUserIdOrCreate(string email);
        public Task UpdateAsync(UserRolesModel model);
        //Task<List<UserRolesModel>> SearchForUserRolesAsync(int userid);
        Task<UserRolesModel> ReadAsync(int id);
        //Task DeleteUserRole(int Id);
    }
}
