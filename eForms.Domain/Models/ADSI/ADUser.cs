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
    //[NotMapped]
    public class ADUser
    {
        //[Key]
        public string samaccountname { get; set; }
        public string mail { get; set; }
        public string displayname { get; set; }
        public string givenName { get; set; }
        public string SN { get; set; }
        public string Department { get; set; }
        public string Office  { get; set; }
        public string telephoneNumber { get; set; }
    }

}
