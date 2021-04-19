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
    public interface IISSOService
    {
        Task<int> CountAsync();
        Task<List<ISSOModel>> GetAllISSO();
        Task<ISSOModel> ReadAsync(int id);
        Task<int> CreateISSO(ISSOModel model);
        public Task UpdateISSOAsync(ISSOModel model);
        Task<List<ISSOModel>> SearchForISSOAsync(string search);
        Task DeleteISSO(int Id);
    }
}
