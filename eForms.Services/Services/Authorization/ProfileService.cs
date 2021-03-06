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

namespace eForms.Services.Interfaces
{
    public class ProfileService : IProfileService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;

        public ProfileService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
        }
        private DbSet<User> GetDbSet()
        {
            return context.tbl_Users;
        }
        
        public async Task<UsersModel> ReadAsync(string id)
        {
            User model = await GetDbSet()
                .Where(x => x.Username == id)
                .FirstOrDefaultAsync();
            return mapper.Map<UsersModel>(model);
        }
        public async Task UpdateProfileAsync(UsersModel model)
        {
            var profile = context.tbl_Users.Where(x => x.Id == model.Id).First();
            profile.OfficePhone = model.OfficePhone;
            await context.SaveChangesAsync();
        }
    }
}
