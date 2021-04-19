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

namespace eForms.Services.Interfaces
{
    public class BuildingService : IBuildingService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public BuildingService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<tbl_rBuildingAnnex> GetDbSet()
        {
            return context.tbl_rBuildingsAnnex;
        }

        public async Task<List<BuildingAnnexModel>> GetAllBuildings()
        {

            List<BuildingAnnexModel> dto = mapper.Map<List<tbl_rBuildingAnnex>, List<BuildingAnnexModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<tbl_rBuildingAnnex> GetQueryable()
        {
            return context.tbl_rBuildingsAnnex;
        }
        public async Task<BuildingAnnexModel> ReadAsync(int id)
        {
            tbl_rBuildingAnnex model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<BuildingAnnexModel>(model);
        }        
        public async Task<int> CreateBuilding(BuildingAnnexModel model)
        {
            tbl_rBuildingAnnex building = mapper.Map<tbl_rBuildingAnnex>(model);
            context.tbl_rBuildingsAnnex.Add(building);
            await context.SaveChangesAsync();
            return building.Id;
        }
        public async Task UpdateBuildingAsync(BuildingAnnexModel model)
        {
            context.tbl_rBuildingsAnnex.Update(mapper.Map<tbl_rBuildingAnnex>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<BuildingAnnexModel>> SearchForBuildingsAsync(string search)
        {
            List<tbl_rBuildingAnnex> agencies = await context.tbl_rBuildingsAnnex
                .Where(x => x.BuildingAnnex.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<BuildingAnnexModel>>(agencies);
        }
        public async Task DeleteBuilding(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageCountries, id);
            context.tbl_rBuildingsAnnex.Remove(new tbl_rBuildingAnnex() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
