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
    public class DefaultModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Comment("Primary key for this table records.")]
        public int Id { get; set; }

        [DefaultValueAttribute(false)]
        public bool Disabled { get; set; }

        [MaxLength(50)]
        [Comment("Name of person who was created the record.")]
        public string CreatedBy { get; set; }

        [Comment("Date and time the record was created.")]
        public DateTime CreatedDate { get; set; }

        [MaxLength(50)]
        [Comment("Name of person who was last updated the record.")]
        public string ModifiedBy { get; set; }

        [Comment("Date and time the record was last updated.")]
        public DateTime ModifiedDate { get; set; }
    }
}
