using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Domain.Models
{
    public class State : DefaultModel
    {
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string StateCapital { get; set; }
    }
}
