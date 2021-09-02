using AutoMapper;
using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc;
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
        private IAuthService authService;
        public BuildingService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer, IAuthService _authService)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            authService = _authService;
        }
        private DbSet<BuildingAnnexes> GetDbSet()
        {
            return context.tbl_rBuildingsAnnex;
        }

        public async Task<List<BuildingAnnexModel>> GetAllBuildings()
        {

            List<BuildingAnnexModel> dto = mapper.Map<List<BuildingAnnexes>, List<BuildingAnnexModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<BuildingAnnexes> GetQueryable()
        {
            return context.tbl_rBuildingsAnnex;
        }
        public async Task<BuildingAnnexModel> ReadAsync(int id)
        {
            BuildingAnnexes model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<BuildingAnnexModel>(model);
        }
        public async Task<int> CreateBuilding(BuildingAnnexModel model)
        {
            BuildingAnnexes building = mapper.Map<BuildingAnnexes>(model);
            context.tbl_rBuildingsAnnex.Add(building);
            await context.SaveChangesAsync();
            return building.Id;
        }
        public async Task UpdateBuildingAsync(BuildingAnnexModel model)
        {
            context.tbl_rBuildingsAnnex.Update(mapper.Map<BuildingAnnexes>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<BuildingAnnexModel>> SearchForBuildingsAsync(string search)
        {
            List<BuildingAnnexes> agencies = await context.tbl_rBuildingsAnnex
                .Where(x => x.BuildingAnnex.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<BuildingAnnexModel>>(agencies);
        }
        public async Task DeleteBuilding(int id)
        {
            //await authService.VerifyRole(Roles.Admin, 0);
            //if (await authService.Check(Roles.Admin, 0) == false)
            //{
            //    //RedirectToActionResult redirectResult = new RedirectToActionResult();
            //    //RedirectToActionResult redirectResult = new RedirectToActionResult("Error", "Error", new { @Id = "401" });
            //    //return redirectResult;
            //    //await redirectResult(401);
            //    //context.tbl_rBuildingsAnnex.Remove(new tbl_rBuildingAnnex() { Id = 0 });
            //}
            //else
            //{
            //    context.tbl_rBuildingsAnnex.Remove(new tbl_rBuildingAnnex() { Id = id });
            //    await context.SaveChangesAsync();
            //}
            context.tbl_rBuildingsAnnex.Remove(new BuildingAnnexes() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
