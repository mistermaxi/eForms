using AutoMapper;
using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
//using Ganss.XSS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Services
{
    public class ADSIService : IADSIService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;

        public ADSIService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<ADUser> GetDbSet()
        {
            return context.vw_ADSI;
        }
        public async Task<string> GetUserAccount(string email)
        {
            ADUser aduser = await context.vw_ADSI
                .Where(x => x.mail == email)
                .FirstOrDefaultAsync();
            return aduser.samaccountname;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<ADUser> GetQueryable()
        {
            return context.vw_ADSI;
        }
        public async Task<List<ADUserModel>> GetAllUsers()
        {

            List<ADUserModel> dto = mapper.Map<List<ADUser>, List<ADUserModel>>(await GetDbSet()
                .OrderBy(item => item.displayname)
                .ToListAsync());

            return dto;
        }
        public async Task<List<ADUserModel>> SearchForUsersAsync(string search)
        {
            List<ADUser> adusers = await context.vw_ADSI
                .Where(x => x.displayname.Contains(search) || x.samaccountname.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<ADUserModel>>(adusers);
        }
        public async Task<ADUserModel> ReadAsync(string search)
        {
            ADUser model = await context.vw_ADSI
                .Where(x => x.mail == search)
                //.Where(x => x.Contains(search) || x.Username.Contains(search))
                //.Where(x => x.Username == search)
                //.Include(x => x.Identity)
                .SingleOrDefaultAsync();
            return mapper.Map<ADUserModel>(model);
        }

    }
}
