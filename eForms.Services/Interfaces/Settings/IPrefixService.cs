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
    public interface IPrefixService
    {
        Task<int> CountAsync();
        Task<List<PrefixModel>> GetAllPrefixes();
        Task<PrefixModel> ReadAsync(int id);
        Task<int> CreatePrefix(PrefixModel model);
        public Task UpdatePrefixAsync(PrefixModel model);
        Task<List<PrefixModel>> SearchForPrefixesAsync(string search);
        Task DeletePrefix(int Id);
    }
}
