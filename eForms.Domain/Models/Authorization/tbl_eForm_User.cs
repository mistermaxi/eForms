using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Domain.Models
{
    public class tbl_eForm_User : DefaultModel
    {
        //[Key]
        //public int Id { get; set; }

        public string Username { get; set; }
        
        public string OfficePhone { get; set; }
        //public bool Disabled { get; set; }
        public string Remark { get; set; }
        public string EmailAddress { get; set; }

        public virtual IList<tbl_eForm_UserRole> UserRolesContext { get; set; }
    }
}
