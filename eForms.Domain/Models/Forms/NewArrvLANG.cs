using eForms.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Domain.Models
{
    public class NewArrvLANG : DefaultModel
    {
        [ForeignKey("NewArrvEMP")]
        [Comment("Used to reference this language talent to New Arrival Employee.")] 
        public int NewArrvEmpID { get; set; }

        [Comment("Other Language apart from English.")]
        public string Language { get; set; }

        [Comment("Speaking Score Level of the language.")]
        public string Speaking { get; set; }

        [Comment("Reading Score Level of the language.")]
        public string Reading { get; set; }

        public virtual NewArrvEMP NewArrvEMP { get; set; }
    }
}
