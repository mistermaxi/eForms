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
    public class Sim : DefaultModel
    {
        public string CellPhoneNo { get; set; }
        public string SIMStatus { get; set; }
        public string Network { get; set; }
        public string IRMNote { get; set; }
        public int TransID { get; set; }
    }
}
