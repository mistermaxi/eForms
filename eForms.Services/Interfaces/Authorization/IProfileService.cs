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
    public interface IProfileService
    {
        //Task<List<tbl_eForm_User>> GetAllUsers();
        //public Task<int> GetUserId(string email);
        //public Task<int> GetUserIdOrCreate(string email);
        public Task UpdateProfileAsync(UsersModel model);
        
        //Task<List<tbl_eForm_User>> SearchForUsersAsync(string search);
        Task<UsersModel> ReadAsync(int id);

        //Task DeleteUser(int Id);
    }
}
