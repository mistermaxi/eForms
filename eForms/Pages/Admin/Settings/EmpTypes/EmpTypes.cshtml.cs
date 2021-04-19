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
    public class EmpTypesModel : PageModel
    {
        public IEnumerable<EmpTypeModel> emptypes { get; set; }

        IEmpTypeService emptypeService;

        public EmpTypesModel(IEmpTypeService _emptypeService)
        {
            emptypeService = _emptypeService;
        }
        public async Task OnGet()
        {
            emptypes = await emptypeService.GetAllEmpTypes();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await emptypeService.DeleteEmpType(id);
            return RedirectToPage("Countries");
        }
    }
}
