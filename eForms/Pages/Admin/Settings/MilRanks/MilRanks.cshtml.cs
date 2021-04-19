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
    public class MilRanksModel : PageModel
    {
        public IEnumerable<MilitaryRankModel> milranks { get; set; }

        IMilitaryRankService milrankService;

        public MilRanksModel(IMilitaryRankService _milrankService)
        {
            milrankService = _milrankService;
        }
        public async Task OnGet()
        {
            milranks = await milrankService.GetAllMilitaryRanks();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await milrankService.DeleteMilitaryRank(id);
            return RedirectToPage("MilRanks");
        }
    }
}
