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
    public interface IIPCService
    {
        Task<int> CountAsync();
        Task<List<IPCModel>> GetAllIPC();
        Task<IPCModel> ReadAsync(int id);
        Task<int> CreateIPC(IPCModel model);
        public Task UpdateIPCAsync(IPCModel model);
        Task<List<IPCModel>> SearchForIPCAsync(string search);
        Task DeleteIPC(int Id);
    }
}
