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
    public interface IBuildingService
    {
        Task<int> CountAsync();
        Task<List<BuildingAnnexModel>> GetAllBuildings();
        Task<BuildingAnnexModel> ReadAsync(int id);
        Task<int> CreateBuilding(BuildingAnnexModel model);
        public Task UpdateBuildingAsync(BuildingAnnexModel model);
        Task<List<BuildingAnnexModel>> SearchForBuildingsAsync(string search);
        Task DeleteBuilding(int Id);
    }
}
