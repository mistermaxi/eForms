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
    public class StatesModel : PageModel
    {
        public IEnumerable<StateModel> states { get; set; }

        IStatesService stateService;

        public StatesModel(IStatesService _stateService)
        {
            stateService = _stateService;
        }
        public async Task OnGet()
        {
            states = await stateService.GetAllStates();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await stateService.DeleteState(id);
            return RedirectToPage("States");
        }
    }
}
