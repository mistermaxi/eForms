using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eForms.Pages.Admin
{
    public class AnnexBuildingsModel : PageModel
    {
        public IEnumerable<BuildingAnnexModel> buildings { get; set; }

        IBuildingService buildingService;

        public AnnexBuildingsModel(IBuildingService _buildingService)
        {
            buildingService = _buildingService;
        }
        public async Task OnGet()
        {
            buildings = await buildingService.GetAllBuildings();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await buildingService.DeleteBuilding(id);
            return RedirectToPage("AnnexBuildings");
        }
    }
}
