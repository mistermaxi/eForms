using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eForms.Services.Models
{
    public class UsersModel : DefaultModel
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string OfficePhone { get; set; }
        public string Remark { get; set; }
        public string EmailAddress { get; set; }
        
        ///////////
        
        public string Role { get; set; }
        public int RoleID { get; set; }
        public int FormId { get; set; }
        public string FormTitle { get; set; }

        ///////////
        public virtual IList<UserRole> UserRoles { get; set; }
        public IEnumerable<string> Roles { get; set; }

        
    }
}
