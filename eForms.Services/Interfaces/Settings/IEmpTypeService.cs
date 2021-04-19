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
    public interface IEmpTypeService
    {
        Task<int> CountAsync();
        Task<List<EmpTypeModel>> GetAllEmpTypes();
        Task<EmpTypeModel> ReadAsync(int id);
        Task<int> CreateEmpType(EmpTypeModel model);
        public Task UpdateEmpTypeAsync(EmpTypeModel model);
        Task<List<EmpTypeModel>> SearchForEmpTypesAsync(string search);
        Task DeleteEmpType(int Id);
    }
}
