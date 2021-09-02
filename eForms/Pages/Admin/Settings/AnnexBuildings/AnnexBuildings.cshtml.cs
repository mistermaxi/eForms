using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eForms.Domain.Enums;

namespace eForms.Pages.Admin
{
    public class AnnexBuildingsModel : PageModel
    {
        public IEnumerable<BuildingAnnexModel> buildings { get; set; }

        IBuildingService buildingService;
        IAuthService authService;

        public AnnexBuildingsModel(IBuildingService _buildingService, IAuthService _authService)
        {
            buildingService = _buildingService;
            authService = _authService;
        }
        public async Task OnGet()
        {
            buildings = await buildingService.GetAllBuildings();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            if (await authService.Check(Roles.Admin, 0) == false)
            {
                return RedirectToPage("/Error", "Error", new { @Id = 401 });
            }
            else
            {
                await buildingService.DeleteBuilding(id);
                return RedirectToPage("AnnexBuildings");
            }
        }
    }
}
