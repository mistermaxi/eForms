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
    public class DS7642Detail : DefaultModel
    {
        [ForeignKey("DS7642")]
        [Comment("Reference to DS7642 main request id.")]
        public int ReqID { get; set; }

        [Comment("Property or IMEI Number of this device record.")]
        public string Property_IMEI { get; set; }

        [Comment("Serial Number of this device record.")]
        public string SerialNumber { get; set; }

        [Comment("Description of SIM Card Number.")]
        public string Desc_SIMNumber { get; set; }

        [Comment("Quantity of this device record.")]
        public string Quantity { get; set; }

        [Comment("Cost per unit of this device record.")]
        public string UnitCost { get; set; }

        [Comment("Total Cost of this device record.")]
        public string TotalCost { get; set; }

        public virtual DS7642 DS7642 { get; set; }
    }
}
