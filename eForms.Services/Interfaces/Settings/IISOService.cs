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
    public interface IISOService
    {
        Task<int> CountAsync();
        Task<List<ISOModel>> GetAllISO();
        Task<ISOModel> ReadAsync(int id);
        Task<int> CreateISO(ISOModel model);
        public Task UpdateISOAsync(ISOModel model);
        Task<List<ISOModel>> SearchForISOAsync(string search);
        Task DeleteISO(int Id);
    }
}
