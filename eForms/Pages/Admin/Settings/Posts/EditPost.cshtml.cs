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
    public class EditPostModel : PageModel
    {
        public IEnumerable<PostModel> posts { get; set; }
        public IEnumerable<CountryModel> countries { get; set; }

        [BindProperty]
        public PostModel post { get; set; }

        [BindProperty]
        public string country_selected { get; set; }

        IPostService postService;
        ICountryService countryService;

        public EditPostModel(IPostService _postService, ICountryService _countryService)
        {
            postService = _postService;
            countryService = _countryService;
        }

        public async Task OnGet(int id)
        {
            countries = await countryService.GetAllCountries();
            post = await postService.ReadAsync(id);
            country_selected = post.PostCountry;
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                post.PostCountry = country_selected;
                await postService.UpdatePostAsync(post);
            }
            return RedirectToPage("Posts");

        }
    }
}
