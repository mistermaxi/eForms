using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Domain.Models
{
    public class Sections : DefaultModel
    {
        public string sectionname { get; set; }
        public string sectionabbr { get; set; }
        public string icasscode { get; set; }

    }
}
