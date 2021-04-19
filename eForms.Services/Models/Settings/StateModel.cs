using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eForms.Services.Models
{
    public class StateModel : DefaultModel
    {
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string StateCapital { get; set; }
    }
}
