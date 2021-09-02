using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eForms.Services.Models
{
    public class NewArrvEMERGModel : DefaultModel
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
