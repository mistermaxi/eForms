using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Models
{
    public class ADUserModel
    {
        public string samaccountname { get; set; }
        public string mail { get; set; }
        public string displayname { get; set; }
        public string givenName { get; set; }
        public string SN { get; set; }
        public string Department { get; set; }
        public string Office { get; set; }
        public string telephoneNumber { get; set; }
    }
}
