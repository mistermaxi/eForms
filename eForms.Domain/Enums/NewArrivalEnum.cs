using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace eForms.Domain.Enums
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "Female")]
        Female,
        [Display(Name = "Decline to specify")]
        Decline,
        [Display(Name = "Other")]
        Other
    }
    public enum USCitizenship
    {
        [Display(Name = "Yes")]
        Yes,
        [Display(Name = "No")]
        No
    }
    public enum FormStatus
    {
        [Display(Name = "Incomplete")]
        Incomplete,
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Completed")]
        Completed
    }
}
