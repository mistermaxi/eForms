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

        public string OfficePhone { get; set; }

        public string Remark { get; set; }
        public string EmailAddress { get; set; }
        public virtual IList<tbl_eForm_UserRole> UserRoles { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
