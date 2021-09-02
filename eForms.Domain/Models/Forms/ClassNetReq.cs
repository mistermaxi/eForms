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
    public class ClassNetReq : DefaultModel
    {
        public string GUID { get; set; }
        public int BCSCID { get; set; }
        public int FormID { get; set; }
        public string ReqFrom { get; set; }
        public string Post { get; set; }
        public bool SIPRNet { get; set; }
        public bool EmailRequired { get; set; }
        public bool CableXpress { get; set; }
        public bool CLOUT { get; set; }
        public bool SMART { get; set; }
        public bool SMARTClassNet { get; set; }
        public string SmartPKI { get; set; }
        public string CurrentClassNetStaus { get; set; }
        public string PreviousPost { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MI { get; set; }
        public string Position { get; set; }
        public string Agency { get; set; }
        public string Section { get; set; }
        public string Location { get; set; }
        public string Extension { get; set; }
        public string EmailAddress { get; set; }
        public string CellPhone { get; set; }
        public string TypeOfID { get; set; }
        public string IDNumber { get; set; }
        public string Citizenship { get; set; }
        public string Clearance { get; set; }
        public string ClassNetEmail { get; set; }
        public string MonthOfDeparture { get; set; }
        public string YearOfDeparture { get; set; }
        public string DateOfDeparture { get; set; }
        public string ApprovedBy { get; set; }
        public string SupervisorEmail { get; set; }
        public string Remarks { get; set; }
        public DateTime SubmitedDate { get; set; }
        public string Comments { get; set; }
        public string SupervisorApprove { get; set; }
        public DateTime SupervisorDate { get; set; }
        public string VerifiedRSO { get; set; }
        public string RSOOptional { get; set; }
        public string RSOApprove { get; set; }
        public string RSOName { get; set; }
        public DateTime RSODate { get; set; }
        public string ISSOApprove { get; set; }
        public DateTime ISSODate { get; set; }
        public string IPCAssigned { get; set; }
        public int IPCStatusADCreated { get; set; }
        public int IPCStatusExCreated { get; set; }
        public int IPCStatusCodeRequest { get; set; }
        public int IPCStatusCodeReceived { get; set; }
        public int IPCStatusSmartLowRoles { get; set; }
        public int IPCStatusSmartHighRoles { get; set; }
        public string IPCStatusComment { get; set; }
        public bool CloseStatus { get; set; }
        public bool ArchiveStatus { get; set; }
    }
}
