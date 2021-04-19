using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Models
{
    public class BuildingAnnexModel : DefaultModel
    {
        [Display(Name = "Building/Annex")]
        public string BuildingAnnex { get; set; }
    }
}
