using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eForms.Services.Models
{
    public class FormModel : DefaultModel
    {
        public string formtitle { get; set; }
        public string formname { get; set; }
        public string formpath { get; set; }
        public string formurl { get; set; }
        public string formediturl { get; set; }

        public bool efm { get; set; }
        public string formefm { get; set; }
        
    }
}
