using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Domain.Models
{
    public class tbl_eForm_UserRole : DefaultModel
    {
        public int UserId { get; set; }
        public int FormId { get; set; }
        public string Roles { get; set; }

    }
}
