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
    public class tbl_rEmployeeType : DefaultModel
    {
        public string EmpType { get; set; }

        [DefaultValueAttribute(false)]
        public bool ISC { get; set; }

        [DefaultValueAttribute(false)] 
        public bool CSC { get; set; }
    }
}
