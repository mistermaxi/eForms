using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;


namespace eForms.Services.Interfaces
{
    public class AuthService : IAuthService
    {
        private IeFormsContext context;
        private IHttpContextAccessor httpContextAccessor;

        public AuthService(IeFormsContext _context, IHttpContextAccessor _httpContextAccessor)
        {
            context = _context;
            httpContextAccessor = _httpContextAccessor;

        }
        public static bool IsInGroup(string groupName)
        {
            var myIdentity = GetUserIdWithDomain();
            var myPrincipal = new WindowsPrincipal(myIdentity);
            return myPrincipal.IsInRole(groupName);
        }

        public bool IsInGroup(List<string> groupNames)
        {
            var myIdentity = GetUserIdWithDomain();
            var myPrincipal = new WindowsPrincipal(myIdentity);

            return groupNames.Any(group => myPrincipal.IsInRole(group));
        }

        public static WindowsIdentity GetUserIdWithDomain()
        {
            var myIdentity = WindowsIdentity.GetCurrent();
            return myIdentity;
        }
        public static string GetUserId()
        {
            var id = GetUserIdWithDomain().Name.Split('\\');
            return id[1];
        }
        public static string GetClaimUser()
        {
            //var username = HttpContext.Current.User.Identity.Name;
            var username = GetUserIdWithDomain().Name.Split('\\');
            return username[1];
        }


        //public static string GetUserDisplayName()
        //{
        //    var id = GetUserIdWithDomain().Name.Split('\\');
        //    ClaimsPrincipal claims = httpContextAccessor.HttpContext.User;

        //    var dc = new PrincipalContext(ContextType.Domain, id[0]);
        //    var adUser = UserPrincipal.FindByIdentity(dc, id[1]);
        //    return adUser.DisplayName;

        //}
        private IQueryable<int> GetIdentity()
        {
            return GetIdentity(context);
        }
        private IQueryable<int> GetIdentity(IeFormsContext ctx)
        {
            ClaimsPrincipal claims = httpContextAccessor.HttpContext.User;
            string email = claims.Claims.Where(x => x.Type == ClaimTypes.Upn).FirstOrDefault().Value;
            return ctx.tbl_eForm_Users
                .Where(x => x.EmailAddress == email)
                .Select(x => x.Id);
        }
        public async Task<bool> Check(Roles role, int formId)
        {
            var username = GetUserIdWithDomain().Name.Split('\\');

            var userid = context.tbl_eForm_Users
                .Where(x => x.Username == username[1])
                .Select(x => x.Id)
                .SingleOrDefault();

            if (userid == 0)
            {
                return false;
            }
            else
            {
                var permissionQuery = context.tbl_eForm_UserRoles
                   .Where(x => x.Role == ExtensionsEnum.GetDisplay(role)
                   && x.UserId == userid)
                   .Select(x => x.Id)
                   .SingleOrDefault();

                if (permissionQuery == 0)
                {
                    return false;
                }
                else
                    return true;
            }

        }
        //public IQueryable<tbl_eForm_UserRole> GetRolesForUser(int userid)
        //{
        //    return GetPermissions(context.tbl_eForm_UserRoles
        //        .Where(x => x.UserId == userid)
        //        .Select(x => x.Role)
        //    );
        //}
        //public IQueryable<tbl_eForm_UserRole> GetPermissions()
        //{
        //    return GetPermissions(GetUserID());
        //}

        public async Task VerifyRole(Roles role, int formId)
        {
            if (!await Check(role, formId)) throw new UnauthorizedAccessException();

            //if (!await Check(role, formId)) throw new HttpResponseException(HttpStatusCode.Unauthorized);
            //if (!await Check(role, formId)) 
            //    throw new ApplicationException(ErrorCodes.UnauthorizedAccess, "This is our custom exception");
            //401 error(Unauthorized access)
        }
        //public async Task VerifyRoleAndFormID(Roles role, int formId)
        //{
        //    if (!await Check(role, formId)) throw new UnauthorizedAccessException();
        //}
        private IQueryable<int> GetUserID(string username)
        {
            //var username = GetUserIdWithDomain().Name.Split('\\');
            return context.tbl_eForm_Users
                    .Where(x => x.Username == username)
                    .Select(x => x.Id);
        }
        //private IQueryable<tbl_eForm_User> GetUserID(IeFormsContext ctx)
        //{
        //    var username = GetUserIdWithDomain().Name.Split('\\');
        //    //string email = claims.Claims.Where(x => x.Type == ClaimTypes.Upn).FirstOrDefault().Value;
        //    return ctx.tbl_eForm_Users
        //        .Where(x => x.Username == username[1].ToString())
        //        .Select(x => x.Id);
        //}

        //public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        //{
        //    var CurrentLoggedInID = GetUserId();
        //    var CurrentLoggedInName = GetClaimUser();
        //    ((ClaimsIdentity)principal.Identity).AddClaim(
        //        new Claim("ExampleClaim", "true"));
        //    return Task.FromResult(principal);
        //}
    }
}
