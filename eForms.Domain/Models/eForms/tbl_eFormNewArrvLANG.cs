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
    public class tbl_eFormNewArrvLANG : DefaultModel
    {
        public int NewArrvEmpID { get; set; }
        public string Language { get; set; }
        public string Speaking { get; set; }
        public string Reading { get; set; }

    }
}
