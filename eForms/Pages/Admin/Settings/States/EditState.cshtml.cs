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
    public class EditStateModel : PageModel
    {
        public IEnumerable<StateModel> states { get; set; }

        [BindProperty]
        public StateModel state { get; set; }


        IStatesService stateService;

        public EditStateModel(IStatesService _stateService)
        {
            stateService = _stateService;
        }

        public async Task OnGet(int id)
        {
            state = await stateService.ReadAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await stateService.UpdateStateAsync(state);
            }
            return RedirectToPage("States");

        }
    }
}
