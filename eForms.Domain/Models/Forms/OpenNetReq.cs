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
    public class OpenNetReq : DefaultModel
    {
        [Comment("GUID number uniquely identifying the record. Used to reference attachment from this request.")]
        public string GUID { get; set; }
        public int BCSCID { get; set; }

        [Comment("Reference this request to Form ID.")]
        public int FormID { get; set; }

        [Comment("User's First Name who request an OpenNet Account.")]
        public string FirstName { get; set; }

        [Comment("User's Last Name who request an OpenNet Account.")]
        public string LastName { get; set; }
        public string MI { get; set; }

        [Comment("Office/Section Name")]
        public string OfficeSymbol { get; set; }
        public string JobTitle { get; set; }

        [Comment("Estimate Arrival Date to Post")]
        public DateTime ESTArrivalDate { get; set; }

        [Comment("Estimate Departure Date to Post")]
        public DateTime ESTDepartureDate { get; set; }

        [Comment("Building or Annex of requester")]
        public string BuildingAnnex { get; set; }

        [Comment("Office Phone Number of requester")]
        public string PhoneNumber { get; set; }

        [Comment("Citizenship of requester")]
        public string Citizenship { get; set; }

        [Comment("DOS Badge Number of requester")]
        public string DOSBadgeNo { get; set; }

        [Comment("Employee Type of requester")]
        public string EmpType { get; set; }
        public string OpenNetStatus { get; set; }
        public string TransferedEmail { get; set; }
        public string PreviousPost { get; set; }
        public DateTime DeptDatePrevPost { get; set; }
        public string DistributionList { get; set; }
        public string AuthOfficerName { get; set; }
        public string AuthOfficerEmail { get; set; }
        public string RequestorName { get; set; }
        public string RequestorEmail { get; set; }
        public DateTime RequestorDate { get; set; }
        public string RequestorRemark { get; set; }
        public string BCSCSenderName { get; set; }
        public string BCSCSenderEmail { get; set; }
        public DateTime BCSCSentDate { get; set; }
        public string AuthApprovalName { get; set; }
        public string AuthApprovalEmail { get; set; }
        public DateTime AuthApprovalDate { get; set; }
        public int AuthApprovalStatus { get; set; }
        public string AuthApprovalRemark { get; set; }

    }
}
