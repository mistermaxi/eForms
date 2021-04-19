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
    public class EditSectionModel : PageModel
    {
        public IEnumerable<SectionModel> offices { get; set; }

        [BindProperty]
        public SectionModel office { get; set; }


        ISectionService officeService;

        public EditSectionModel(ISectionService _officeService)
        {
            officeService = _officeService;
        }

        public async Task OnGet(int id)
        {
            office = await officeService.ReadAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await officeService.UpdateSectionAsync(office);
            }
            return RedirectToPage("Sections");

        }
    }
}
