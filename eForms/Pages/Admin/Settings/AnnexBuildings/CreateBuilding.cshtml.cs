using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using eForms.Domain.Enums;

namespace eForms.Pages.Admin
{
    public class CreateBuildingModel : PageModel
    {
        public IEnumerable<BuildingAnnexModel> buildings { get; set; }

        [BindProperty]
        public BuildingAnnexModel building { get; set; }


        IBuildingService buildingService;
        IAuthService authService;

        public CreateBuildingModel(IBuildingService _buildingService, IAuthService _authService)
        {
            buildingService = _buildingService;
            authService = _authService;
        }

        public async Task<IActionResult> OnGet()
        {
            if (await authService.Check(Roles.Manager, 0) == false)
            {
                return RedirectToPage("/Error", "Error", new { @Id = 401 });
            }
            else
            {
                buildings = await buildingService.GetAllBuildings();
                return Page();
            }
            

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
