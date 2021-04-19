using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace eForms.Services.Models
{
    public class DefaultModel
    {
        public int Id { get; set; }
        //public int FormId { get; set; }
        //public int RoleId { get; set; }

        [Display(Name = "Is Disabled?")]
        public bool Disabled { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }

        //public string Email { get; set; }
        //public string DisplayName { get; set; }
        //public OrgStatus Active { get; set; }
        //public int OfficeId { get; set; }
        //public virtual Office Office { get; set; }
        //public int AgencyId { get; set; }
        //public virtual Agency Agency { get; set; }
        //public int PostId { get; set; }
        //public bool IsAdmin { get; set; }
    }
}
