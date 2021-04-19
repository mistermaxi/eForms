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
    public class tbl_eFormReqOpenNet : DefaultModel
    {
        public string GUID { get; set; }
        public int BCSCID { get; set; }
        public int FormID { get; set; }

    }
}
