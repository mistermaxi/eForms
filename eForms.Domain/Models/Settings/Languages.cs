using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace eForms.Domain.Models
{
    public class Languages : DefaultModel
    {
        public string LangCode { get; set; }
        public string LangDesc { get; set; }
    }
}
