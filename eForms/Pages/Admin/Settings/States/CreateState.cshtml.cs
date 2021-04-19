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
    public class CreateStateModel : PageModel
    {
        public IEnumerable<StateModel> states { get; set; }

        [BindProperty]
        public StateModel state { get; set; }


        IStatesService stateService;

        public CreateStateModel(IStatesService _stateService)
        {
            stateService = _stateService;
        }

        public async Task OnGet()
        {
            states = await stateService.GetAllStates();

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await stateService.CreateState(state);
                return RedirectToPage("States");
            }
            else
            {
                return Page();
            }

        }
    }
}
