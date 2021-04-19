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
    public class EditMilitaryRankModel : PageModel
    {
        public IEnumerable<MilitaryRankModel> milranks { get; set; }

        [BindProperty]
        public MilitaryRankModel milrank { get; set; }

        IMilitaryRankService milrankService;

        public EditMilitaryRankModel(IMilitaryRankService _milrankService)
        {
            milrankService = _milrankService;
        }

        public async Task OnGet(int id)
        {
            milrank = await milrankService.ReadAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await milrankService.UpdateMilitaryRankAsync(milrank);
            }
            return RedirectToPage("MilRanks");

        }
    }
}
