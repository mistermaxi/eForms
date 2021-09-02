using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;

namespace eForms.Pages.Form
{
    public class CreateClassNetReqModel : PageModel
    {
        public IEnumerable<ClassNetModel> forms { get; set; }
        public IEnumerable<eForms.Services.Models.ADUserModel> adusers { get; set; }
        public IEnumerable<SectionModel> sections { get; set; }


        [BindProperty]
        public ClassNetModel form { get; set; }

        [BindProperty]
        public string aduser_selected { get; set; }

        [BindProperty]
        public string section_selected { get; set; }

        IClassNetService formService;
        ISectionService sectionService;
        IADSIService adsiService;

        public CreateClassNetReqModel(IClassNetService _formService, ISectionService _sectionService, IADSIService _adsiService)
        {
            formService = _formService;
            sectionService = _sectionService;
            adsiService = _adsiService;
        }

        public async Task OnGet()
        {
            adusers = await adsiService.GetAllUsers();
            sections = await sectionService.GetAllSections();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                form.EmailAddress = aduser_selected;
                form.Section = section_selected;

                await formService.CreateNewRequest(form);
                return RedirectToPage("AnnexBuildings");
            }
                adusers = await adsiService.GetAllUsers();
            sections = await sectionService.GetAllSections();

            return Page();
        }
    }
}
