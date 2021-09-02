using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace eForms.Pages.Dashboard
{
    public class CSCModel : PageModel
    {
        public IEnumerable<NewArrvEMPModel> newarrivals { get; set; }

        INewArrivalService newarrivalService;

        public CSCModel(INewArrivalService _newarrivalService)
        {
            newarrivalService = _newarrivalService;
        }
        public async Task OnGet()
        {
            newarrivals = await newarrivalService.GetAllNewArrival();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await newarrivalService.DeleteNewArrival(id);
            return RedirectToPage("CSC");
        }
    }
}
