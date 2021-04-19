using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eForms.Pages.Admin
{
    public class EditBuildingModel : PageModel
    {
        public IEnumerable<BuildingAnnexModel> buildings { get; set; }

        [BindProperty]
        public BuildingAnnexModel building { get; set; }
        
        IBuildingService buildingService;

        public EditBuildingModel(IBuildingService _buildingService)
        {
            buildingService = _buildingService;
        }

        public async Task OnGet(int id)
        {
            building = await buildingService.ReadAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await buildingService.UpdateBuildingAsync(building);
            }
            return RedirectToPage("AnnexBuildings");

        }
    }
}
