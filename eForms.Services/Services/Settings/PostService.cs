using AutoMapper;
using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eForms.Services.Services
{
    public class PostService : IPostService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public PostService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<Posts> GetDbSet()
        {
            return context.tbl_rPosts;
        }

        public async Task<List<PostModel>> GetAllPosts()
        {

            List<PostModel> dto = mapper.Map<List<Posts>, List<PostModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<Posts> GetQueryable()
        {
            return context.tbl_rPosts;
        }
        public async Task<PostModel> ReadAsync(int id)
        {
            Posts model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<PostModel>(model);
        }
        public async Task<int> CreatePost(PostModel model)
        {
            Posts post = mapper.Map<Posts>(model);
            context.tbl_rPosts.Add(post);
            await context.SaveChangesAsync();
            return post.Id;
        }
        public async Task UpdatePostAsync(PostModel model)
        {
            context.tbl_rPosts.Update(mapper.Map<Posts>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<PostModel>> SearchForPostsAsync(string search)
        {
            List<Posts> posts = await context.tbl_rPosts
                .Where(x => x.PostCity.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<PostModel>>(posts);
        }
        public async Task DeletePost(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageMilRank, id);
            context.tbl_rPosts.Remove(new Posts() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
