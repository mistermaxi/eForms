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
    public class Model : DefaultModel
    {
        public string ModelName { get; set; }
        public string ModelDesc { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
    }
}
