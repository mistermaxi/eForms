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
        private IAuthService authService;

        public UserService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer, IAuthService _authService)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            authService = _authService;
        }

        private DbSet<User> GetDbSet()
        {
            return context.tbl_Users;
        }
        private DbSet<UserRole> GetUserRoleDbSet()
        {
            return context.tbl_UserRoles;
        }
        public async Task<int> GetUserId(string email)
        {
            User user = await context.tbl_Users
                .Where(x => x.EmailAddress == email)
                .FirstOrDefaultAsync();
            return user.Id;
        }

        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<User> GetQueryable()
        {
            return context.tbl_Users;
        }
        public async Task<List<UsersModel>> GetAllUsers()
        {
            //List<UsersModel> dto = mapper.Map<List<User>, List<UsersModel>>(await GetDbSet().ToListAsync());
            //return dto;
            //var x = context.tbl_UserRoles.ToList();

            //var result = from role in context.tbl_UserRoles
            //             join form in context.tbl_rForms on role.FormId equals form.Id into Details
            //             from m in Details.DefaultIfEmpty()
            //             select new
            //             {
            //                 result_id = role.Id,
            //                 result_userid = role.UserId,
            //                 result_formname = role.Form.formname,
            //                 result_userrole = role.Role
            //             };

            //var result = from role in context.tbl_UserRoles
            //             join form in context.tbl_rForms on role.FormId equals form.Id into Details
            //             from m in Details.DefaultIfEmpty()
            //             join user in context.tbl_Users on m.UerRole.UserId equals user.Id into userroleformGroup
            //             from p in userroleformGroup.DefaultIfEmpty()
            //             //from p in userroleformGroup.()
            //             select new
            //             {
            //                 result_id = role.Id,
            //                 result_userid = role.UserId,
            //                 result_username = role.User.Username,
            //                 result_displayname = role.User.DisplayName,
            //                 result_email = role.User.EmailAddress,
            //                 result_phone = role.User.OfficePhone,
            //                 result_disabled = role.User.Disabled,
            //                 result_formname = role.Form.formname,
            //                 result_userrole = role.Role,
            //                 result_modifieddate = role.User.ModifiedDate,
            //                 result_modifiedby = role.User.ModifiedBy
            //             };

            //var UserAndRoles = result
            //    .Select(m => new UsersModel 
            //    { 
            //        Id = m.result_id,
            //        Username = m.result_username,
            //        DisplayName = m.result_displayname,
            //        EmailAddress = m.result_email,
            //        FormName = m.result_formname,
            //        OfficePhone = m.result_phone,
            //        //Remark = m.TableUser.Remark,
            //        Role = m.result_userrole,
            //        //FormId = m.TableRole.FormId,
            //        Disabled = m.result_disabled,
            //        //CreatedBy = m.TableUser.CreatedBy,
            //        //CreatedDate = m.TableUser.CreatedDate,
            //        ModifiedBy = m.result_modifiedby,
            //        ModifiedDate = m.result_modifieddate
            //    }).ToListAsync();



            //var UserAndRoles = context.tbl_Users
            //                            .Join(context.tbl_UserRoles, TableUser => TableUser.Id, TableRole => TableRole.UserId, (TableUser, TableRole) => new { TableUser, TableRole })
            //                            //.Join(context.Offices, Relaciondedos => Relaciondedos.TablaIntermedia.OfficeId, TablaFinal => TablaFinal.Id, (Relaciondedos, TablaFinal) => new { Relaciondedos, TablaFinal })
            //                            //.Where(m => m.Relaciondedos.TablaIntermedia.IsOfficeOwner == true)
            //                            .Select(m => new UsersModel
            //                            {
            //                                Id = m.TableUser.Id,
            //                                RoleID = m.TableRole.Id,
            //                                Username = m.TableUser.Username,
            //                                DisplayName = m.TableUser.DisplayName,
            //                                EmailAddress = m.TableUser.EmailAddress,
            //                                OfficePhone = m.TableUser.OfficePhone,
            //                                Remark = m.TableUser.Remark,
            //                                Role = m.TableRole.Role,
            //                                FormId = m.TableRole.FormId,
            //                                Disabled = m.TableUser.Disabled,
            //                                CreatedBy = m.TableUser.CreatedBy,
            //                                CreatedDate = m.TableUser.CreatedDate,
            //                                ModifiedBy = m.TableUser.ModifiedBy,
            //                                ModifiedDate = m.TableUser.ModifiedDate
            //                            }
            //                            ).ToListAsync();

            var UserAndRoles = context.tbl_Users
                                        .Join(context.tbl_UserRoles, TableUser => TableUser.Id, TableRole => TableRole.UserId, (TableUser, TableRole) => new { TableUser, TableRole })
                                        .Join(context.tbl_rForms, TableUser => TableUser.TableRole.FormId, TableFinal => TableFinal.Id, (TableForm, TableFinal) => new { TableForm, TableFinal })
                                        //.Where(m => m.TableForm.TableUser.Disabled == false)
                                        .Select(m => new UsersModel
                                        {
                                            Id = m.TableForm.TableUser.Id,
                                            RoleID = m.TableForm.TableRole.Id,
                                            Username = m.TableForm.TableUser.Username,
                                            DisplayName = m.TableForm.TableUser.DisplayName,
                                            EmailAddress = m.TableForm.TableUser.EmailAddress,
                                            OfficePhone = m.TableForm.TableUser.OfficePhone,
                                            Remark = m.TableForm.TableUser.Remark,
                                            Role = m.TableForm.TableRole.Role,
                                            FormId = m.TableForm.TableRole.FormId,
                                            FormTitle = m.TableFinal.formtitle,
                                            Disabled = m.TableForm.TableRole.Disabled,
                                            CreatedBy = m.TableForm.TableUser.CreatedBy,
                                            CreatedDate = m.TableForm.TableUser.CreatedDate,
                                            ModifiedBy = m.TableForm.TableUser.ModifiedBy,
                                            ModifiedDate = m.TableForm.TableUser.ModifiedDate
                                        }
                                        )
                                        .ToListAsync();


            List<UsersModel> dto = await UserAndRoles;

            return dto;
        }

        public async Task<int> CreateUserRole(UsersModel umodel, UserRolesModel model, string email, int formid)
        {

            var UserAndRoles = context.tbl_Users
                     .Join(context.tbl_UserRoles, TableUser => TableUser.Id, TableRole => TableRole.UserId, (TableUser, TableRole) => new { TableUser, TableRole })
                    .Join(context.tbl_rForms, TableUser => TableUser.TableRole.FormId, TableFinal => TableFinal.Id, (TableForm, TableFinal) => new { TableForm, TableFinal })
                    .Where(j => j.TableForm.TableRole.FormId == formid && j.TableForm.TableUser.EmailAddress == email)
                    .Select(m => new UsersModel
                    {
                        Id = m.TableForm.TableUser.Id,
                        RoleID = m.TableForm.TableRole.Id,
                        Username = m.TableForm.TableUser.Username,
                        DisplayName = m.TableForm.TableUser.DisplayName,
                        EmailAddress = m.TableForm.TableUser.EmailAddress,
                        OfficePhone = m.TableForm.TableUser.OfficePhone,
                        Remark = m.TableForm.TableUser.Remark,
                        Role = m.TableForm.TableRole.Role,
                        FormId = m.TableForm.TableRole.FormId,
                        FormTitle = m.TableFinal.formtitle,
                        Disabled = m.TableForm.TableRole.Disabled,
                        CreatedBy = m.TableForm.TableUser.CreatedBy,
                        CreatedDate = m.TableForm.TableUser.CreatedDate,
                        ModifiedBy = m.TableForm.TableUser.ModifiedBy,
                        ModifiedDate = m.TableForm.TableUser.ModifiedDate
                    }
                    ).Take(1).ToListAsync();

            List<UsersModel> dto = await UserAndRoles;

            int return_userid = 0;

            if (dto.Count == 0)
            {
                User x = await GetDbSet()
                .Where(item => item.EmailAddress == email)
                .FirstOrDefaultAsync();

                var existsUser = mapper.Map<UsersModel>(x);

                if (x is null)
                {
                    User adduser = mapper.Map<User>(umodel);
                    context.tbl_Users.Add(adduser);
                    await context.SaveChangesAsync();

                    UserRole userrole = mapper.Map<UserRole>(model);
                    userrole.UserId = adduser.Id;
                    context.tbl_UserRoles.Add(userrole);
                    await context.SaveChangesAsync();
                    return_userid = userrole.Id;
                }
                else
                {
                    UserRole userrole = mapper.Map<UserRole>(model);
                    userrole.UserId = existsUser.Id;
                    context.tbl_UserRoles.Add(userrole);
                    await context.SaveChangesAsync();
                    return_userid = userrole.Id;
                }

            }
            return return_userid;
        }

        public async Task<UsersModel> ReadUserRoleAsync(int id)
        {
            var UserAndRoles = await context.tbl_Users
                     .Join(context.tbl_UserRoles, TableUser => TableUser.Id, TableRole => TableRole.UserId, (TableUser, TableRole) => new { TableUser, TableRole })
                    .Join(context.tbl_rForms, TableUser => TableUser.TableRole.FormId, TableFinal => TableFinal.Id, (TableForm, TableFinal) => new { TableForm, TableFinal })
                    .Where(m => m.TableForm.TableRole.Id == id)
                    .Select(m => new UsersModel
                    {
                        Id = m.TableForm.TableUser.Id,
                        RoleID = m.TableForm.TableRole.Id,
                        Username = m.TableForm.TableUser.Username,
                        DisplayName = m.TableForm.TableUser.DisplayName,
                        EmailAddress = m.TableForm.TableUser.EmailAddress,
                        OfficePhone = m.TableForm.TableUser.OfficePhone,
                        Remark = m.TableForm.TableUser.Remark,
                        Role = m.TableForm.TableRole.Role,
                        FormId = m.TableForm.TableRole.FormId,
                        FormTitle = m.TableFinal.formtitle,
                        Disabled = m.TableForm.TableRole.Disabled,
                        CreatedBy = m.TableForm.TableRole.CreatedBy,
                        CreatedDate = m.TableForm.TableRole.CreatedDate,
                        ModifiedBy = m.TableForm.TableRole.ModifiedBy,
                        ModifiedDate = m.TableForm.TableRole.ModifiedDate
                    }
                    ).SingleOrDefaultAsync();

            return mapper.Map<UsersModel>(UserAndRoles);
        }

        public async Task<List<UsersModel>> SearchForUsersAsync(string search)
        {
            List<User> users = await context.tbl_Users
                .Where(x => x.EmailAddress.Contains(search) || x.Username.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<UsersModel>>(users);
        }

        public async Task<UsersModel> ReadAsync(string search)
        {
            User model = await context.tbl_Users
                //.Where(x => x.Id == id)
                //.Where(x => x.Contains(search) || x.Username.Contains(search))
                //.Where(x => x.Username == search)
                //.Include(x => x.Identity)
                .SingleOrDefaultAsync();
            return mapper.Map<UsersModel>(model);
        }
        public async Task<UsersModel> ReadUserNameAsync(string search)
        {
            var UserAndRoles = await context.tbl_Users
                     .Join(context.tbl_UserRoles, TableUser => TableUser.Id, TableRole => TableRole.UserId, (TableUser, TableRole) => new { TableUser, TableRole })
                    .Where(m => m.TableUser.Username == search)
                    .Select(m => new UsersModel
                    {
                        Id = m.TableUser.Id,
                        Username = m.TableUser.Username,
                        DisplayName = m.TableUser.DisplayName,
                        EmailAddress = m.TableUser.EmailAddress,
                        Role = m.TableRole.Role,
                        Disabled = m.TableRole.Disabled
                    }
                    ).SingleOrDefaultAsync();

            return mapper.Map<UsersModel>(UserAndRoles);
        }
        public async Task UpdateAsync(UsersModel model)
        {
            var userrole = context.tbl_UserRoles.Where(x => x.Id == model.RoleID).First();
            userrole.Role = model.Role;
            userrole.Disabled = model.Disabled;
            await context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            // Check UserID records in USerRole Table

            UserRole x = await GetUserRoleDbSet()
                .Where(item => item.Id == id)
                .FirstOrDefaultAsync();

            var existsUser = mapper.Map<UserRolesModel>(x);
            

            var UserAndRoles = context.tbl_UserRoles
                     .Where(j => j.UserId == existsUser.UserId)
                    .Select(m => new UserRolesModel
                    {
                        Id = m.Id,
                        UserId = m.UserId
                    }
                    ).Take(2).ToListAsync();

            List<UserRolesModel> dto = await UserAndRoles;
            if (dto.Count == 2)
            {
                context.tbl_UserRoles.Remove(new UserRole() { Id = id });
                await context.SaveChangesAsync();
            }
            else
            {
                var user = context.tbl_Users.Single(a => a.Id == existsUser.UserId);
                var roles = context.tbl_UserRoles.Where(b => b.UserId == existsUser.UserId);
                foreach (var role in roles)
                {
                    context.tbl_UserRoles.Remove(role);
                }
                context.tbl_Users.Remove(user);
                await context.SaveChangesAsync();

            }
            
        }
        
    }
}
