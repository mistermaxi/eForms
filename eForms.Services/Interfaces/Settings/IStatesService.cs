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
    public interface IStatesService
    {
        Task<int> CountAsync();
        Task<List<StateModel>> GetAllStates();
        Task<StateModel> ReadAsync(int id);
        Task<int> CreateState(StateModel model);
        public Task UpdateStateAsync(StateModel model);
        Task<List<StateModel>> SearchForStatesAsync(string search);
        Task DeleteState(int Id);
    }
}
