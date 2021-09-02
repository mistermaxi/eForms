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
using eForms.Domain.Enums;

namespace eForms.Pages.Admin
{
    public class EditBuildingModel : PageModel
    {
        public IEnumerable<BuildingAnnexModel> buildings { get; set; }

        [BindProperty]
        public BuildingAnnexModel building { get; set; }
        
        IBuildingService buildingService;
        IAuthService authService;
        public EditBuildingModel(IBuildingService _buildingService, IAuthService _authService)
        {
            buildingService = _buildingService;
            authService = _authService;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            if (await authService.Check(Roles.Manager, 0) == false)
            {
                return RedirectToPage("/Error", "Error", new { @Id = 401 });
            }
            else
            {
                building = await buildingService.ReadAsync(id);
                return Page();
            }
            
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
