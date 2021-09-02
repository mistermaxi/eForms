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
    public class IPC : DefaultModel
    {
        [Comment("IPC Staff Name")]
        public string Name { get; set; }
        [Comment("IPC Staff Position")]
        public string Position { get; set; }
        [Comment("IPC Staff Email")]
        public string Email { get; set; }
        [Comment("IPC Staff Phone")]
        public string Phone { get; set; }

        [Comment("IPC Staff Record Remark")]
        public string Remark { get; set; }
    }
}
