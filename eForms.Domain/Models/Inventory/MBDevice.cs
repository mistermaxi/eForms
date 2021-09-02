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
    public class MBDevice : DefaultModel
    {

        public string PropertyNo { get; set; }
        public string SerialNo { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string DeviceStatus { get; set; }
        public int TransID { get; set; }
        public string OfficeSymbol { get; set; }
        public string FundSource { get; set; }
        public string PONumber { get; set; }
        public string Cost { get; set; }
        public string Remark { get; set; }
    }
}
