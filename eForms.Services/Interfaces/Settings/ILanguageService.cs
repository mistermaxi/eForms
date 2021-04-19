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
    public interface ILanguageService
    {
        Task<int> CountAsync();
        Task<List<LanguageModel>> GetAllLanguages();
        Task<LanguageModel> ReadAsync(int id);
        Task<int> CreateLanguage(LanguageModel model);
        public Task UpdateLanguageAsync(LanguageModel model);
        Task<List<LanguageModel>> SearchForLanguagesAsync(string search);
        Task DeleteLanguage(int Id);
    }
}
