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
    public interface IUserService
    {
        Task<List<UsersModel>> GetAllUsers();
        public Task<int> GetUserId(string email);
        public Task<int> CreateUserRole(UsersModel umodel, UserRolesModel model, string email, int formid);

        public Task UpdateAsync(UsersModel model);
        Task<List<UsersModel>> SearchForUsersAsync(string search);
        Task<UsersModel> ReadAsync(string search);
        Task<UsersModel> ReadUserNameAsync(string search);
        Task<UsersModel> ReadUserRoleAsync(int id);

        Task DeleteUser(int Id);
    }
}
