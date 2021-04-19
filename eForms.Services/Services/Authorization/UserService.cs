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

namespace eForms.Services.Interfaces
{
    public class UserService : IUserService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;

        public UserService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }

        private DbSet<tbl_eForm_User> GetDbSet()
        {
            return context.tbl_eForm_Users;
        }
        private async Task<tbl_eForm_User> EnsureExists(tbl_eForm_User user, string email)
        {
            if (user != null) return user;
            user = new tbl_eForm_User() { EmailAddress = email };
            context.tbl_eForm_Users.Add(user);
            await context.SaveChangesAsync();
            //context.Entry(user).State = EntityState.Detached;
            return user;
        }

        public async Task<int> GetUserIdOrCreate(string email)
        {
            tbl_eForm_User user = await context.tbl_eForm_Users
                .Where(x => x.EmailAddress == email)
                .FirstOrDefaultAsync();
            user = await EnsureExists(user, email);
            return user.Id;
        }

        public async Task<int> GetUserId(string email)
        {
            tbl_eForm_User user = await context.tbl_eForm_Users
                .Where(x => x.EmailAddress == email)
                .FirstOrDefaultAsync();
            return user.Id;
        }

        public async Task UpdateAsync(UsersModel model)
        {
            context.tbl_eForm_Users.Update(mapper.Map<tbl_eForm_User>(model));
            await context.SaveChangesAsync();
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<tbl_eForm_User> GetQueryable()
        {
            return context.tbl_eForm_Users;
        }
        //public async Task<List<tbl_eForm_User>> GetAllUsers()
        //{
        //    List<tbl_eForm_User> users = await context.tbl_eForm_Users
        //        //.Include(x => x.Office)
        //        //.Include(x => x.Agency)
        //        .ToListAsync();
        //    return mapper.Map<List<tbl_eForm_User>>(users);
            
        //}
        public async Task<List<UsersModel>> GetAllUsers()
        {

            List<UsersModel> dto = mapper.Map<List<tbl_eForm_User>, List<UsersModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<List<UsersModel>> SearchForUsersAsync(string search)
        {
            List<tbl_eForm_User> users = await context.tbl_eForm_Users
                .Where(x => x.EmailAddress.Contains(search) || x.Username.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<UsersModel>>(users);
        }

        public async Task<UsersModel> ReadAsync(string search)
        {
            tbl_eForm_User model = await context.tbl_eForm_Users
                //.Where(x => x.Id == id)
                //Where(x => x.EmailAddress == mail)
                .Where(x => x.Username == search)
                //.Include(x => x.Identity)
                .SingleOrDefaultAsync();
            return mapper.Map<UsersModel>(model);
        }

        public async Task DeleteUser(int id)
        {
            context.tbl_eForm_Users.Remove(new tbl_eForm_User() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
