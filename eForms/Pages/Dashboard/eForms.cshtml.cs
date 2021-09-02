using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eForms.Domain.Enums;

namespace eForms.Pages
{
    public class eFormsModel : PageModel
    {
        public IEnumerable<eFormModel> eformRequests { get; set; }

        IeFormService eformService;
        IAuthService authService;
        public eFormsModel(IeFormService _eformService, IAuthService _authService)
        {
            eformService = _eformService;
            authService = _authService;
        }
        public async Task OnGet()
        {
            eformRequests = await eformService.GetAlleForm();
        }
       
    }
}
