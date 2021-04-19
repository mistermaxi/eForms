using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Models
{
    public class EmpTypeModel : DefaultModel
    {
        [Display(Name = "Employee Type")]
        public string EmpType { get; set; }
        public bool ISC { get; set; }
        public bool CSC { get; set; }

    }
}
