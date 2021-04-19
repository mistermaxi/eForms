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
    public class FormsModel : PageModel
    {
        public IEnumerable<FormModel> forms { get; set; }

        IFormService formService;

        public FormsModel(IFormService _formService)
        {
            formService = _formService;
        }
        public async Task OnGet()
        {
            forms = await formService.GetAllForms();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await formService.DeleteForm(id);
            return RedirectToPage("Countries");
        }
    }
}
