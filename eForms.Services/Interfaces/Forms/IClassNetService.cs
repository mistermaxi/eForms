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
    public interface IClassNetService
    {
        Task<int> CountAsync();
        Task<List<ClassNetModel>> GetAllRequest();
        Task<ClassNetModel> ReadAsync(int id);
        Task<int> CreateNewRequest(ClassNetModel model);
        public Task UpdateRequestAsync(ClassNetModel model);
        Task<List<ClassNetModel>> SearchForRequestsAsync(string search);
        Task DeleteRequest(int Id);
    }
}
