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
    public class RelationshipsModel : PageModel
    {
        public IEnumerable<RelationshipModel> relationships { get; set; }

        IRelationshipService relationshipService;

        public RelationshipsModel(IRelationshipService _relationshipService)
        {
            relationshipService = _relationshipService;
        }
        public async Task OnGet()
        {
            relationships = await relationshipService.GetAllRelationship();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await relationshipService.DeleteRelationship(id);
            return RedirectToPage("Relationships");
        }
    }

}
