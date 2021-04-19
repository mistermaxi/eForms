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
    public class PostsModel : PageModel
    {
        public IEnumerable<PostModel> posts { get; set; }

        IPostService postService;

        public PostsModel(IPostService _postService)
        {
            postService = _postService;
        }
        public async Task OnGet()
        {
            posts = await postService.GetAllPosts();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await postService.DeletePost(id);
            return RedirectToPage("Posts");
        }
    }
}
