using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public interface IAuthService
    {
        public Task VerifyRole(Roles role, int formId);
        public string GetUserWithoutDomain();
        public Task<bool> Check(Roles role, int formId);

        public bool IsInGroup(string groupName);
        public bool IsInGroups(List<string> groupNames);
    }
}
