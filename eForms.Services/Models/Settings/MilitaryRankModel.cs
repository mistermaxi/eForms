using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Models
{
    public class MilitaryRankModel : DefaultModel
    {
        [Display(Name = "Military Rank")]
        public string MilitaryRank { get; set; }
    }
}
