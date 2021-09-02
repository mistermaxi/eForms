using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eForms.Services.Models
{
    public class NewArrvLANGModel : DefaultModel
    {
        public int NewArrvEmpID { get; set; }
        public string Language { get; set; }
        public string Speaking { get; set; }
        public string Reading { get; set; }
    }
}
