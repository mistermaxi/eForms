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
        public string EmailAddress { get; set; }
        public string OfficePhone { get; set; }        

        public string Remark { get; set; }
        
        //public string Roles { get; set; }
        public virtual tbl_eForm_UserRole tbl_eForm_UserRole { get; set; }        
        //public IEnumerable<string> Roles { get; set; }
    }
}
