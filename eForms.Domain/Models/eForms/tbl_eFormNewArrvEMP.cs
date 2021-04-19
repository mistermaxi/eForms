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
    public class tbl_eFormNewArrvEMP : DefaultModel
    {
        public string GUID { get; set; }
        public int BCSCID { get; set; }
        public int FormID { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MI { get; set; }
        public DateTime DOB { get; set; }
        public string CountryOfBirth { get; set; }
        public string Gender { get; set; }
        public string OfficeSymbol { get; set; }
        public string JobTitle { get; set; }
        public string DiplomaticTitle { get; set; }
        public DateTime ExpectedArrivalDate { get; set; }
        public DateTime TransferEligibilityDate { get; set; }
        public string BuildingAnnex { get; set; }
        public string OfficePhone { get; set; }
        public string OfficialEmail { get; set; }
        public string PersonalEmail { get; set; }
        public string USCitizen { get; set; }
        public string SecurityClearance { get; set; }
        public string SSN4Digits { get; set; }
        public string DOSBadgeNo { get; set; }
        public string EmpType { get; set; }
        public string PayPlan { get; set; }
        public string Grade { get; set; }
        public string Step { get; set; }
        public string MilitaryRank { get; set; }
        public string PreviousPost { get; set; }
        public int TourOfDuty { get; set; }
        public string E2UserType { get; set; }
        public string TravelArranger { get; set; }
        public string EmpNameBeingReplaced { get; set; }
        public string OpenNetUserID { get; set; }
        public string ClassNetUserID { get; set; }
        public string FirstSecondTour { get; set; }
        public string HomeLeaveAddr { get; set; }
        public string HomeLeaveCity { get; set; }
        public string HomeLeaveState { get; set; }
        public string HomeLeaveZip { get; set; }
        public string HomeLeavePhone { get; set; }
        public string USPhoneNumber { get; set; }
        public string DPOBoxNumberAddr { get; set; }
        public string SupervisorName { get; set; }
        public string SupervisorEmail { get; set; }
        public string ChiefName { get; set; }
        public string ChiefEmail { get; set; }
        public string SponsorPrefix { get; set; }
        public string SponsorFirstName { get; set; }
        public string SponsorLastName { get; set; }
        public string SponsorMI { get; set; }
        public string SponsorEmail { get; set; }
        public string SponsorDOSBadgeNo { get; set; }
        public string SponsorOfficePhone { get; set; }
        public string SponsorType { get; set; }
        public string SponsorOtherType { get; set; }
        public string MyServicesAccountType { get; set; }
        public string MyServicesServiceProvider { get; set; }
        public string MyServicesApprover { get; set; }
        public string RequestorName { get; set; }
        public string RequestorEmail { get; set; }
        public DateTime RequestorDate { get; set; }
        public string RequestorRemark { get; set; }
        public int Status { get; set; }
        public DateTime CancelledDate { get; set; }
        public string CancelledByName { get; set; }
        public string CancelledByEmail { get; set; }
        public string CancelledRemark { get; set; }
        public int ArchivedStatus { get; set; }
        public DateTime ArchivedDate { get; set; }
        public string ArchivedByName { get; set; }
        public string ArchivedByEmail { get; set; }
        public string IPAddress { get; set; }
    }
}
