using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Models
{
    public class LanguageModel : DefaultModel
    {
        [Display(Name = "Language Code")]
        public string LangCode { get; set; }

        [Display(Name = "Language Desc")]
        public string LangDesc { get; set; }
    }
}
