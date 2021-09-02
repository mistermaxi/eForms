using eForms.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Domain.Models
{
    public class NewArrvEMERG : DefaultModel
    {
        [ForeignKey("NewArrvEMP")]
        [Comment("Used to reference this Emergency Contact to New Arrival Employee.")]
        public int NewArrvEmpID { get; set; }

        [Comment("Emergency Contact's First Name")]
        public string FirstName { get; set; }

        [Comment("Emergency Contact's Last Name")]
        public string LastName { get; set; }

        [Comment("Emergency Contact's Middle Name")]
        public string MI { get; set; }

        [Comment("Emergency Contact's relationship with Employee")]
        public string Relationship { get; set; }

        [Comment("Emergency Contact's email")]
        public string Email { get; set; }

        [Comment("Emergency Contact's phone number")]
        public string Phone { get; set; }

        [Comment("Emergency Contact's home leave address")]
        public string HomeLeaveAddr { get; set; }

        public virtual NewArrvEMP NewArrvEMP { get; set; }

    }
}
