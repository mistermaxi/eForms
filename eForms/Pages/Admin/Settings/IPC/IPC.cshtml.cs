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
    public class IPCModel : PageModel
    {
        public IEnumerable<eForms.Services.Models.IPCModel> ipcs { get; set; }

        IIPCService ipcService;

        public IPCModel(IIPCService _ipcService)
        {
            ipcService = _ipcService;
        }
        public async Task OnGet()
        {
            ipcs = await ipcService.GetAllIPC();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await ipcService.DeleteIPC(id);
            return RedirectToPage("IPC");
        }
    }
}
