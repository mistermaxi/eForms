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
    public interface IADSIService
    {
        Task<List<ADUserModel>> GetAllUsers();
        Task<List<ADUserModel>> SearchForUsersAsync(string search);
        Task<ADUserModel> ReadAsync(string search);
        public Task<String> GetUserAccount(string email);

    }
}
