using eForms.Domain.Enums;
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
    public class NewArrvDEP : DefaultModel
    {
        [ForeignKey("NewArrvEMP")]
        [Comment("Used to reference this Dependent information to New Arrival Employee.")]
        public int NewArrvEmpID { get; set; }

        [Comment("Dependent's First Name")]
        public string FirstName { get; set; }

        [Comment("Dependent's Last Name")]
        public string LastName { get; set; }

        [Comment("Dependent's Middle Name")]
        public string MI { get; set; }

        [Comment("Dependent's Date of Birth")]
        public DateTime DOB { get; set; }

        [Comment("Relationship of this Dependent's record.")]
        public string Relationship { get; set; }

        [Comment("Dependent's Gender")]
        public string Gender { get; set; }

        [Comment("SSN's Last 4 digits of this Dependent's record.")]
        public string SSN4Digits { get; set; }

        [Comment("Nationality of this Dependent's record.")]
        public string Nationality { get; set; }

        [Comment("Hometown Address of this Dependent's record.")]
        public string Hometown { get; set; }

        [Comment("Email Address of this Dependent's record.")]
        public string Email { get; set; }

        [Comment("Phone Number of this Dependent's record.")]
        public string Phone { get; set; }

        [Comment("Home Leave Address of this Dependent's record.")]
        public string HomeLeaveAddr { get; set; }

        [Comment("Home Leave City of this Dependent's record.")]
        public string HomeLeaveCity { get; set; }

        [Comment("Home Leave State of this Dependent's record.")]
        public string HomeLeaveState { get; set; }

        [Comment("Home Leave Zip Code of this Dependent's record.")]
        public string HomeLeaveZip { get; set; }

        [Comment("Home Leave Phone of this Dependent's record.")]
        public string HomeLeavePhone { get; set; }
        public string Domiciled { get; set; }

        [Comment("Emergency Contact Person of this Dependent's record.")]
        public string EmergContactName { get; set; }

        [Comment("Emergency Contact's Relationship of this Dependent's record.")]
        public string EmergRelationship { get; set; }

        [Comment("Emergency Contact's Address of this Dependent's record.")]
        public string EmergAddr { get; set; }

        [Comment("Emergency Contact's Phone of this Dependent's record.")]
        public string EmergPhone { get; set; }

        [Comment("Spouse's Status of this Dependent's record.")]
        public bool IsSpouse { get; set; }

        public virtual NewArrvEMP NewArrvEMP { get; set; }
    }
}
