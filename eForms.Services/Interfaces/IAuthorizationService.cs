using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public interface IAuthorizationService
    {
        public Task<bool> CheckFullAccess(eFormRole permission);
        public Task<bool> Check(eFormRole permission, int scopeId);
        public Task<List<tbl_eForm_UserRole>> ListPermissions(List<eFormRole> eformroles);
        public IQueryable<tbl_eForm_UserRole> GetPermissions();
        public IQueryable<tbl_eForm_UserRole> GetPermissionsForUser(int userId);
    }
}
