using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;

namespace eForms.Pages.Admin
{
    public class CreateBuildingModel : PageModel
    {
        public IEnumerable<BuildingAnnexModel> buildings { get; set; }

        [BindProperty]
        public BuildingAnnexModel building { get; set; }


        IBuildingService buildingService;

        public CreateBuildingModel(IBuildingService _buildingService)
        {
            buildingService = _buildingService;
        }

        public async Task OnGet()
        {
            buildings = await buildingService.GetAllBuildings();

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await buildingService.CreateBuilding(building);
                return RedirectToPage("AnnexBuildings");
            }
            else
            {
                return Page();
            }

        }
    }
}
