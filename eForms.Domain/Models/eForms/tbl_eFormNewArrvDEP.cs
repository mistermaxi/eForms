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
    public class tbl_eFormNewArrvDEP : DefaultModel
    {
        public int NewArrvEmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MI { get; set; }
        public DateTime DOB { get; set; }
        public string Relationship { get; set; }
        public string Gender { get; set; }
        public string SSN4Digits { get; set; }
        public string Nationality { get; set; }
        public string Hometown { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string HomeLeaveAddr { get; set; }
        public string HomeLeaveCity { get; set; }
        public string HomeLeaveState { get; set; }
        public string HomeLeaveZip { get; set; }
        public string HomeLeavePhone { get; set; }
        public string Domiciled { get; set; }
        public string EmergContactName { get; set; }
        public string EmergRelationship { get; set; }
        public string EmergAddr { get; set; }
        public string EmergPhone { get; set; }
        public bool IsSpouse { get; set; }
    }
}
