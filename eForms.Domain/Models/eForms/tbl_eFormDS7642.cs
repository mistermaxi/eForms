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
    public class tbl_eFormDS7642 : DefaultModel
    {
        public string GUID { get; set; }
        public int FormID { get; set; }
        public int BCSCID { get; set; }
        public string Post { get; set; }
        public string Agency { get; set; }
        public string OfficeSymbol { get; set; }
        public string PhoneNumber { get; set; }
        public int Equipment_Cellphone { get; set; }
        public int Equipment_IronKey { get; set; }
        public int Equipment_Android { get; set; }
        public int Equipment_iPhone { get; set; }
        public int Equipment_SIM { get; set; }
        public int Equipment_Laptops { get; set; }
        public int Equipment_Tablet { get; set; }
        public int Equipment_GODesktop { get; set; }
        public int Action_IssueRequest { get; set; }
        public int Action_LoanRequest { get; set; }
        public DateTime DateLoanBegin { get; set; }
        public DateTime DateLoanEnd { get; set; }
        public string RequestorName { get; set; }
        public string RequestorEmail { get; set; }
        public DateTime RequestorDate { get; set; }
        public string RequestorRemark { get; set; }
        public string AuthOfficerName { get; set; }
        public string AuthOfficerEmail { get; set; }
        public string AuthApprovalName { get; set; }
        public string AuthApprovalEmail { get; set; }
        public DateTime AuthApprovalDate { get; set; }
        public int AuthApprovalStatus { get; set; }
        public string AuthApprovalRemark { get; set; }        
        public string PropertyRecordsUpdatedByName { get; set; }
        public string PropertyRecordsUpdatedByEmail { get; set; }
        public DateTime PropertyRecordsUpdatedDate { get; set; }
        public int PropertyRecordsUpdatedStatus { get; set; }
        public string ReceivedByName { get; set; }
        public string ReceivedByEmail { get; set; }
        public DateTime ReceivedByDate { get; set; }
        public int ReceivedByStatus { get; set; }
        public string CancelledByName { get; set; }
        public string CancelledByEmail { get; set; }
        public DateTime CancelledDate { get; set; }
        public string CancelledRemark { get; set; }
        public int Status { get; set; }
    }
}
