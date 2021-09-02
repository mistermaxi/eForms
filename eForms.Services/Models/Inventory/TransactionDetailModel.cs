using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eForms.Services.Models
{
    public class TransactionDetailModel : DefaultModel
    {
        public int RequestID { get; set; }
        public int MobileDeviceID { get; set; }
        public int SimID { get; set; }
        public DateTime IssuedDate { get; set; }
        public string IssuedBy { get; set; }
    }
}
