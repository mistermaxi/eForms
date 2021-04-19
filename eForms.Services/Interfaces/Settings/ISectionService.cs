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
    public interface ISectionService
    {
        Task<int> CountAsync();
        Task<List<SectionModel>> GetAllSections();
        Task<SectionModel> ReadAsync(int id);
        Task<int> CreateSection(SectionModel model);
        public Task UpdateSectionAsync(SectionModel model);
        Task<List<SectionModel>> SearchForSectionsAsync(string search);
        Task DeleteSection(int Id);
    }
}
