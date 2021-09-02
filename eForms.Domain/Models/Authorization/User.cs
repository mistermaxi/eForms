using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Domain.Models
{
    public class User : DefaultModel
    {
        [Comment("User's Logon Name")]
        public string Username { get; set; }

        [Comment("User's Displayname")]
        public string DisplayName { get; set; }

        [Comment("User's Office Phone")]
        public string OfficePhone { get; set; }
        
        [Comment("User's Email Address")]
        public string EmailAddress { get; set; }

        [Comment("Remark for this User")]
        public string Remark { get; set; }

    }
}
