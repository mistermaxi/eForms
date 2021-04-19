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
        //public string EmailAddress { get; set; }
        public Roles RoleName { get; set; }
        //public IEnumerable<string> Roles { get; set; }
    }
}
