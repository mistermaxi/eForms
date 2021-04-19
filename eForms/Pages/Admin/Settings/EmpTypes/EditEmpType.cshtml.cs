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
    public class EditEmpTypeModel : PageModel
    {
        public IEnumerable<EmpTypeModel> emptypes { get; set; }

        [BindProperty]
        public EmpTypeModel emptype { get; set; }

        IEmpTypeService emptypeService;

        public EditEmpTypeModel(IEmpTypeService _emptypeService)
        {
            emptypeService = _emptypeService;
        }

        public async Task OnGet(int id)
        {
            emptype = await emptypeService.ReadAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await emptypeService.UpdateEmpTypeAsync(emptype);
            }
            return RedirectToPage("EmpTypes");

        }
    }
}
