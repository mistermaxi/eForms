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
    public class Transaction : DefaultModel
    {
        public int RequestID { get; set; }
        public int MobileDeviceID { get; set; }
        public int SimID { get; set; }
        public DateTime IssuedDate { get; set; }
        public string IssuedBy { get; set; }
        

    }
}
