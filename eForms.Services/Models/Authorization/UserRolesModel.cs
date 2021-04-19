using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eForms.Services.Models
{
    public class UserRolesModel : DefaultModel
    {
        public int UserId { get; set; }
        public int FormId { get; set; }
        public Roles Roles { get; set; }
        //public virtual tbl_eForm_UserRole tbl_eForm_UserRole { get; set; }
        public virtual tbl_rForm tbl_rForm { get; set; }
    }
}
