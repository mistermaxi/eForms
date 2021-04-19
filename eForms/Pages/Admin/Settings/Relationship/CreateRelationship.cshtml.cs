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
    public class CreateRelationshipModel : PageModel
    {
        public IEnumerable<RelationshipModel> relationships { get; set; }
        
        [BindProperty]
        public RelationshipModel relationship { get; set; }

        IRelationshipService relationshipService;


        public CreateRelationshipModel(IRelationshipService _relationshipService)
        {
            relationshipService = _relationshipService;
        }

        public async Task OnGet()
        {
            relationships = await relationshipService.GetAllRelationship();

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await relationshipService.CreateRelationship(relationship);
                return RedirectToPage("Relationships");
            }
            else
            {
                return Page();
            }

        }
    }
}
