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
    public class SectionsModel : PageModel
    {
        public IEnumerable<SectionModel> offices { get; set; }

        ISectionService officeService;

        public SectionsModel(ISectionService _officeService)
        {
            officeService = _officeService;
        }
        public async Task OnGet()
        {
            offices = await officeService.GetAllSections();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await officeService.DeleteSection(id);
            return RedirectToPage("Sections");
        }
    }
}
