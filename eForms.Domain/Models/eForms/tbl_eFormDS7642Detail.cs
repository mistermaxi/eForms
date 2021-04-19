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
    public class tbl_eFormDS7642Detail
    {
        public int ReqID { get; set; }
        public string Property_IMEI { get; set; }
        public string SerialNumber { get; set; }
        public string Desc_SIMNumber { get; set; }
        public string Quantity { get; set; }
        public string UnitCost { get; set; }
        public string TotalCost { get; set; }
    }
}
