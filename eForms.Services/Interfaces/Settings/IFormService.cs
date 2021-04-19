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
    public interface IFormService
    {
        Task<int> CountAsync();
        Task<List<FormModel>> GetAllForms();
        Task<FormModel> ReadAsync(int id);
        Task<int> CreateForm(FormModel model);
        public Task UpdateFormAsync(FormModel model);
        Task<List<FormModel>> SearchForFormsAsync(string search);
        Task DeleteForm(int Id);
    }
}
