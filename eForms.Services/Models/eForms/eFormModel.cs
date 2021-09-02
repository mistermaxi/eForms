using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Models
{
    public class eFormModel : DefaultModel
    {
        public int FormID { get; set; }
        public string ReqFrom { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MI { get; set; }
        public string Section { get; set; }
        public string EmailAddress { get; set; }
        public int AuthApprovalStatus { get; set; }
        public int ISSOApprovalStatus { get; set; }
        public int RSOApprovalStatus { get; set; }

        public string Status { get; set; }

    }
}
