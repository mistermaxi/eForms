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
    public interface IOpenNetService
    {
        Task<int> CountAsync();
        Task<List<OpenNetModel>> GetAllRequest();
        Task<OpenNetModel> ReadAsync(int id);
        Task<int> CreateNewRequest(OpenNetModel model);
        public Task UpdateRequestAsync(OpenNetModel model);
        Task<List<OpenNetModel>> SearchForRequestsAsync(string search);
        Task DeleteRequest(int Id);
    }
}
