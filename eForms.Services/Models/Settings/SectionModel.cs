using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Models
{
    public class SectionModel : DefaultModel
    {
        [Display(Name = "Section Name")]
        public string sectionname { get; set; }

        [Display(Name = "Section Abbr")]
        public string sectionabbr { get; set; }

        [Display(Name = "ICASS Code")]
        public string icasscode { get; set; }

    }
}
