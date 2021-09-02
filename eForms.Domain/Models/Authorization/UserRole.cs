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
    public class UserRole : DefaultModel
    {

        [ForeignKey("User")]
        [Comment("Identify a user of this role")]
        public int UserId { get; set; }

        [Comment("Identify a form of this user's role.")]
        public int FormId { get; set; }

        [Comment("Role of this UserId")]
        public string Role { get; set; }

        public virtual User User { get; set; }
        public virtual Forms Form { get; set; }
    }
}
