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
    public class CreateEmpTypeModel : PageModel
    {
        public IEnumerable<EmpTypeModel> emptypes { get; set; }

        [BindProperty]
        public EmpTypeModel emptype { get; set; }


        IEmpTypeService emptypeService;

        public CreateEmpTypeModel(IEmpTypeService _emptypeService)
        {
            emptypeService = _emptypeService;
        }

        public async Task OnGet()
        {
            emptypes = await emptypeService.GetAllEmpTypes();

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await emptypeService.CreateEmpType(emptype);
                return RedirectToPage("EmpTypes");
            }
            else
            {
                return Page();
            }

        }
    }
}
