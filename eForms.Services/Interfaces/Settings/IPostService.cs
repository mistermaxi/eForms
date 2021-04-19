using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public interface IPostService
    {
        Task<int> CountAsync();
        Task<List<PostModel>> GetAllPosts();
        Task<PostModel> ReadAsync(int id);

        //[Authorize(Roles = "Administrator,SuperAdmin")] 
        Task<int> CreatePost(PostModel model);
        public Task UpdatePostAsync(PostModel model);
        Task<List<PostModel>> SearchForPostsAsync(string search);
        Task DeletePost(int Id);
    }
}
