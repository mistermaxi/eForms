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
    public interface INewArrivalService
    {
        Task<int> CountAsync();
        Task<List<NewArrvEMPModel>> GetAllNewArrival();
        Task<NewArrvEMPModel> ReadAsync(int id);
        Task<int> CreateNewArrival(NewArrvEMPModel model);
        public Task UpdateNewArrivalAsync(NewArrvEMPModel model);
        Task<List<NewArrvEMPModel>> SearchForNewArrivalsAsync(string search);
        Task DeleteNewArrival(int Id);
    }
}
