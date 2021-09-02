using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace eForms.Domain.Enums
{
    public enum eFormStatus
    {
        [Display(Name = "New Request")]
        NewRequest,
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Completed")]
        Completed,
        [Display(Name = "Cancelled")]
        Cancelled
    }
    public enum AuthApprovalStatus
    {
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Approved")]
        Completed,
        [Display(Name = "Disapproved")]
        Cancelled
    }
    public enum RSOApprovalStatus
    {
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Approved")]
        Completed,
        [Display(Name = "Disapproved")]
        Cancelled
    }
    public enum ISSOApprovalStatus
    {
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Approved")]
        Completed,
        [Display(Name = "Disapproved")]
        Cancelled
    }
    public enum AccountCreateStatus
    {
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Completed")]
        Completed
    }
    public enum AccountReceiveStatus
    {
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Completed")]
        Completed
    }
    public enum OpenNetRequestType
    {
        [Display(Name = "New Account")]
        New,
        [Display(Name = "Transfer Account")]
        Transfer
    }
    public enum ApprovalStatus
    {
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Approved")]
        Completed,
        [Display(Name = "Disapproved")]
        Cancelled
    }
    public enum EmailStatus
    {
        Opened = 0,
        Sent = 1,
        Failed = 2
    }
    public enum eFormRole
    {
        [Display(Name = "User")]
        User,
        [Display(Name = "Manager")]
        Manager,
        [Display(Name = "Administrator")]
        Admin
    }
    public enum Months
    {
        [Display(Name = "January")]
        Jan = 1,
        [Display(Name = "February")] 
        Feb = 2,
        [Display(Name = "March")] 
        Mar=3,
        [Display(Name = "April")] 
        Apr=4,
        [Display(Name = "May")] 
        May=5,
        [Display(Name = "June")] 
        Jun=6,
        [Display(Name = "July")] 
        Jul=7,
        [Display(Name = "August")] 
        Aug=8,
        [Display(Name = "September")] 
        Sep=9,
        [Display(Name = "October")] 
        Oct=10,
        [Display(Name = "November")] 
        Nov=11,
        [Display(Name = "December")] 
        Dec=12 
    }
    //public enum PostTypes
    //{
    //    [Display(Name = "Consulate General")]
    //    CG,
    //    [Display(Name = "East Asia & Pacific")]
    //    EAP,
    //    [Display(Name = "Europe & Euraisa")]
    //    EUR,
    //    [Display(Name = "April")]
    //    IO,
    //    [Display(Name = "Near East")]
    //    NEA,
    //    [Display(Name = "South & Central Asia")]
    //    SCA,
    //    [Display(Name = "U.S.A. And U.S. Territories")]
    //    WHA
    //}
    public enum PostBureaus
    {
        [Display(Name = "Africa")]
        AF,
        [Display(Name = "East Asia & Pacific")]
        EAP,
        [Display(Name = "Europe & Euraisa")]
        EUR,
        [Display(Name = "April")]
        IO,
        [Display(Name = "Near East")]
        NEA,
        [Display(Name = "South & Central Asia")]
        SCA,
        [Display(Name = "U.S.A. And U.S. Territories")]
        WHA
    }
    public enum DisabledOptions
    {
        [Display(Name = "False")]
        False = 0,
        [Display(Name = "True")]
        True = 1
    }
    public enum LanguageLevel
    {
        [Display(Name = "0")]
        Zero,
        [Display(Name = "0+")]
        ZeroPlus,
        [Display(Name = "1")]
        One,
        [Display(Name = "1+")]
        OnePlus,
        [Display(Name = "2")]
        Two,
        [Display(Name = "2+")]
        TwoPlus,
        [Display(Name = "3")]
        Three,
        [Display(Name = "3+")]
        ThreePlus,
        [Display(Name = "4")]
        Four,
        [Display(Name = "4+")]
        FourPlus,
        [Display(Name = "5")]
        Five
    }
    public enum MessageType { Success, Error, Info, Warning };
    

}
