using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace eForms.Domain.Enums
{
    public enum SimStatus
    {
        [Display(Name = "ACTIVE")]
        ACTIVE,
        [Display(Name = "DEACTIVATED")]
        DEACTIVATED,
        [Display(Name = "ISSUED")]
        ISSUED,
        [Display(Name = "SUSPENDED")]
        SUSPENDED
    }
    public enum DeviceStatus
    {
        [Display(Name = "IN-STOCK")]
        INSTOCK,
        [Display(Name = "ISSUED")]
        ISSUED,
        [Display(Name = "DISPOSE/DEFECT")]
        DISPOSE,
        [Display(Name = "DEGAUSS")]
        DEGAUSS,
        [Display(Name = "LOST")]
        LOST
    }
    public enum MobileNetwork
    {
        [Display(Name = "AIS")]
        AIS,
        [Display(Name = "TRUE")]
        TRUE,
        [Display(Name = "DTAC")]
        DTAC
    }
}
