using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace eForms.Domain.Models
{
    public class Forms : DefaultModel
    {
        public string formtitle { get; set; }
        public string formname { get; set; }
        public string formpath { get; set; }
        public string formurl { get; set; }
        public string formediturl { get; set; }

        [DefaultValueAttribute(false)]
        public bool efm { get; set; }
        public string formefm { get; set; }

    }
}
