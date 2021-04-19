using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public class AuthorizationService : IAuthorizationService
    {
        private IeFormsContext context;
        private IHttpContextAccessor httpContextAccessor;
        public AuthorizationService(IeFormsContext _context, IHttpContextAccessor _httpContextAccessor)
        {
            context = _context;
            httpContextAccessor = _httpContextAccessor;

        }


        public async Task Challenge(eFormRole permission, int scopeId)
        {
            if (!await Check(permission, scopeId)) throw new UnauthorizedAccessException();
        }

        public async Task ChallengeFullAccess(eFormRole permission)
        {
            await Challenge(permission, 0);
        }

        public async Task<bool> CheckFullAccess(eFormRole permission)
        {
            return await Check(permission, 0);
        }

        public async Task<bool> Check(eFormRole permission, int scopeId)
        {
            if (await GetPermissions()
                .Where(x => x.PermissionType == permission && x.ScopeId == scopeId)
                .AnyAsync())
                return true;
            if (await IsAdmin())
                return true;
            return false;
        }

        public async Task<PermissionScope> CheckScope(eFormRole permission)
        {
            var scope = await GetPermissions()
                .Where(x => x.PermissionType == permission)
                .Select(x => Math.Abs(x.ScopeId))
                .MinAsync(x => (int?)x);

            return scope.HasValue ? (scope.Value == 0 ? PermissionScope.Any : PermissionScope.Some) : PermissionScope.None;
        }

        public IQueryable<DBModel> FilterQueryable<DBModel>(eFormRole permission, IeFormsContext ctx, IQueryable<DBModel> queryable) where DBModel : Entity, new()
        {
            var queryableIdentity = GetIdentity(ctx);
            var permQuery = ctx.Permissions
                    .Where(x => (x.IdentityId.HasValue && queryableIdentity.Any(i => i.Id == x.IdentityId))
                             || (x.GroupId.HasValue && queryableIdentity.Any(i => i.IdentityGroupPairs.Any(g => g.GroupId == x.GroupId.Value))));

            return queryable.Where(x => permQuery.Any(y => y.ScopeId == x.Id && y.PermissionType == permission));
        }

        private IQueryable<Identity> GetIdentity()
        {
            return GetIdentity(context);
        }

        private IQueryable<Identity> GetIdentity(IeDipNotesContext ctx)
        {
            ClaimsPrincipal claims = httpContextAccessor.HttpContext.User;
            if (claims.Identity.AuthenticationType.Equals("token"))
            {
                int id = int.Parse(claims.Claims.Where(x => x.Type == "client app id").FirstOrDefault().Value);
                return ctx.ClientApps
                    .Where(x => x.Id == id)
                    .Select(x => x.Identity);
            }
            else
            {
                string email = claims.Claims.Where(x => x.Type == ClaimTypes.Upn).FirstOrDefault().Value;
                return ctx.Users
                    .Where(x => x.EMail == email)
                    .Select(x => x.Identity);
            }
        }

        public async Task<IList<int>> ListScopes(eFormRole permission)
        {
            return await GetPermissions()
                .Where(x => x.PermissionType == permission)
                .Select(x => x.ScopeId)
                .ToListAsync();
        }

        public async Task<List<tbl_eForm_UserRole>> ListPermissions(List<eFormRole> permissionTypes)
        {
            return await GetPermissions()
                .Where(x => permissionTypes.Contains(x.PermissionType))
                .ToListAsync();
        }

        private IQueryable<tbl_eForm_UserRole> GetPermissions(IQueryable<Identity> queryableIdentity)
        {
            return context
                    .tbl_eForm_UserRoles
                    .Where(x => (x.IdentityId.HasValue && queryableIdentity.Any(i => i.Id == x.IdentityId))
                             || (x.GroupId.HasValue && queryableIdentity.Any(i => i.IdentityGroupPairs.Any(g => g.GroupId == x.GroupId.Value))));
        }

        public IQueryable<Permission> GetPermissions()
        {
            return GetPermissions(GetIdentity());
        }

        public IQueryable<Permission> GetPermissionsForIdentity(int identityId)
        {
            return GetPermissions(context.Identities.Where(x => x.Id == identityId));
        }

        public IQueryable<Permission> GetPermissionsForUser(int userId)
        {
            return GetPermissions(context.Users
                .Where(x => x.Id == userId)
                .Select(x => x.Identity)
            );
        }

        public IQueryable<Permission> GetPermissionsForClientApp(int clientAppId)
        {
            return GetPermissions(context.ClientApps
                .Where(x => x.Id == clientAppId)
                .Select(x => x.Identity)
            );
        }

        public IQueryable<Permission> GetPermissionsForGroup(int groupId)
        {
            return context.Groups
                .Where(x => x.Id == groupId)
                .SelectMany(x => x.Permissions);
        }

        public async Task GrantPermissions(bool isGroup, int id, List<eFormRole> types, int scopeId)
        {
            await ChallengeFullAccess(eFormRole.ManagePermissions);
            context.Permissions.AddRange(types.Select(x =>
                isGroup ?
                    new Permission()
                    {
                        GroupId = id,
                        PermissionType = x,
                        ScopeType = PermissionEnums.ScopeOf(x),
                        ScopeId = scopeId
                    }
                :
                    new Permission()
                    {
                        IdentityId = id,
                        PermissionType = x,
                        ScopeType = PermissionEnums.ScopeOf(x),
                        ScopeId = scopeId
                    }
            ));
            await context.SaveChangesAsync();
        }

        public async Task GrantPermission(bool isGroup, int id, eFormRole type, int scopeId)
        {
            await GrantPermissions(isGroup, id, new List<eFormRole>() { type }, scopeId);
        }

        public async Task RevokePermissions(bool isGroup, int id, List<eFormRole> types, int scopeId)
        {
            await ChallengeFullAccess(eFormRole.ManagePermissions);
            IQueryable<Permission> baseQuery = isGroup ?
                context.Permissions.Where(x => x.GroupId == id) :
                context.Permissions.Where(x => x.IdentityId == id);
            List<Permission> permissions = await baseQuery
                .Where(x => types.Contains(x.PermissionType))
                .Where(x => x.ScopeId == scopeId)
                .ToListAsync();
            context.Permissions.RemoveRange(permissions);
            await context.SaveChangesAsync();
        }

        public async Task RevokePermission(bool isGroup, int id, eFormRole type, int scopeId)
        {
            await RevokePermissions(isGroup, id, new List<eFormRole>() { type }, scopeId);
        }

        public async Task SetPermission(bool isGroup, int id, eFormRole type, int scopeId, bool value)
        {
            if (value) await GrantPermission(isGroup, id, type, scopeId);
            else await RevokePermission(isGroup, id, type, scopeId);
        }

        public async Task SetPermissions(bool isGroup, int id, List<eFormRole> permissionTypes, int scopeId, bool value)
        {
            if (value) await GrantPermissions(isGroup, id, permissionTypes, scopeId);
            else await RevokePermissions(isGroup, id, permissionTypes, scopeId);
        }

        public async Task SetPermissionForUser(int userId, eFormRole type, int scopeId, bool value)
        {
            int identityId = (await context.tbl_eForm_UserRoles
                .Where(x => x.Id == userId)
                .Select(x => x.IdentityId)
                .FirstOrDefaultAsync()).Value;
            await SetPermission(false, identityId, type, scopeId, value);
        }

        public async Task SetPermissionsForUser(int userId, List<eFormRole> permissionTypes, int scopeId, bool value)
        {
            int identityId = (await context.tbl_eForm_UserRoles
                .Where(x => x.Id == userId)
                .Select(x => x.IdentityId)
                .FirstOrDefaultAsync()).Value;
            await SetPermissions(false, identityId, permissionTypes, scopeId, value);
        }

        //public async Task SetPermissionForClientApp(int clientAppId, eFormRole type, int scopeId, bool value)
        //{
        //    int identityId = await context.ClientApps
        //        .Where(x => x.Id == clientAppId)
        //        .Select(x => x.IdentityId)
        //        .FirstOrDefaultAsync();
        //    await SetPermission(false, identityId, type, scopeId, value);
        //}

        //public async Task SetPermissionsForClientApp(int clientAppId, List<eFormRole> permissionTypes, int scopeId, bool value)
        //{
        //    int identityId = await context.ClientApps
        //        .Where(x => x.Id == clientAppId)
        //        .Select(x => x.IdentityId)
        //        .FirstOrDefaultAsync();
        //    await SetPermissions(false, identityId, permissionTypes, scopeId, value);
        //}

        public async Task SetPermissionForGroup(int groupId, eFormRole type, int scopeId, bool value)
        {
            await SetPermission(true, groupId, type, scopeId, value);
        }

        public async Task SetPermissionsForGroup(int groupId, List<eFormRole> permissionTypes, int scopeId, bool value)
        {
            await SetPermissions(true, groupId, permissionTypes, scopeId, value);
        }

        public async Task<bool> IsAdmin()
        {
            return await GetIdentity()
                            .Where(i => i.Users.Any(u => u.IsAdmin))
                            .AnyAsync();
        }
    }
}
