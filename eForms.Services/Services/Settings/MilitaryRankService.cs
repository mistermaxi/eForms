using AutoMapper;
using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Services
{
    public class MilitaryRankService : IMilitaryRankService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public MilitaryRankService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<MilitaryRanks> GetDbSet()
        {
            return context.tbl_rMilitaryRanks;
        }

        public async Task<List<MilitaryRankModel>> GetAllMilitaryRanks()
        {

            List<MilitaryRankModel> dto = mapper.Map<List<MilitaryRanks>, List<MilitaryRankModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<MilitaryRanks> GetQueryable()
        {
            return context.tbl_rMilitaryRanks;
        }
        public async Task<MilitaryRankModel> ReadAsync(int id)
        {
            MilitaryRanks model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<MilitaryRankModel>(model);
        }
        public async Task<int> CreateMilitaryRank(MilitaryRankModel model)
        {
            MilitaryRanks militaryrank = mapper.Map<MilitaryRanks>(model);
            context.tbl_rMilitaryRanks.Add(militaryrank);
            await context.SaveChangesAsync();
            return militaryrank.Id;
        }
        public async Task UpdateMilitaryRankAsync(MilitaryRankModel model)
        {
            context.tbl_rMilitaryRanks.Update(mapper.Map<MilitaryRanks>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<MilitaryRankModel>> SearchForMilitaryRanksAsync(string search)
        {
            List<MilitaryRanks> militaryranks = await context.tbl_rMilitaryRanks
                .Where(x => x.MilitaryRank.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<MilitaryRankModel>>(militaryranks);
        }
        public async Task DeleteMilitaryRank(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageMilRank, id);
            context.tbl_rMilitaryRanks.Remove(new MilitaryRanks() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
