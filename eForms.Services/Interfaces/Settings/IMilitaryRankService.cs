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
    public interface IMilitaryRankService
    {
        Task<int> CountAsync();
        Task<List<MilitaryRankModel>> GetAllMilitaryRanks();
        Task<MilitaryRankModel> ReadAsync(int id);
        Task<int> CreateMilitaryRank(MilitaryRankModel model);
        public Task UpdateMilitaryRankAsync(MilitaryRankModel model);
        Task<List<MilitaryRankModel>> SearchForMilitaryRanksAsync(string search);
        Task DeleteMilitaryRank(int Id);
    }
}
