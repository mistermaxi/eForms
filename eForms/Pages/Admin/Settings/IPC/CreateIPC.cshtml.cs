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
    public class CreateIPCModel : PageModel
    {
        public IEnumerable<eForms.Services.Models.IPCModel> ipcs { get; set; }

        [BindProperty]
        public eForms.Services.Models.IPCModel ipc { get; set; }


        IIPCService ipcService;

        public CreateIPCModel(IIPCService _ipcService)
        {
            ipcService = _ipcService;
        }

        public async Task OnGet()
        {
            ipcs = await ipcService.GetAllIPC();

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await ipcService.CreateIPC(ipc);
                return RedirectToPage("IPC");
            }
            else
            {
                return Page();
            }

        }
    }
}
