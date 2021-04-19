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
        //public int FormId { get; set; }
        //public int RoleId { get; set; }

        public string Username { get; set; }

        public string OfficePhone { get; set; }
        

        public string Remark { get; set; }
        public string EmailAddress { get; set; }
    }
}
