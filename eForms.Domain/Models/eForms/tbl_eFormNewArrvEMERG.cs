using eForms.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Domain.Models
{
    public class tbl_eFormNewArrvEMERG : DefaultModel
    {
        public int NewArrvEmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MI { get; set; }
        public string Relationship { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string HomeLeaveAddr { get; set; }
    }
}
