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
    public class CreateMilitaryRankModel : PageModel
    {
        public IEnumerable<MilitaryRankModel> milranks { get; set; }

        [BindProperty]
        public MilitaryRankModel milrank { get; set; }


        IMilitaryRankService milrankService;

        public CreateMilitaryRankModel(IMilitaryRankService _milrankService)
        {
            milrankService = _milrankService;
        }

        public async Task OnGet()
        {
            milranks = await milrankService.GetAllMilitaryRanks();

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await milrankService.CreateMilitaryRank(milrank);
                return RedirectToPage("MilRanks");
            }
            else
            {
                return Page();
            }

        }
    }
}
