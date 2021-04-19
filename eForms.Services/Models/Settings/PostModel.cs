using eForms.Domain.Enums;
using eForms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eForms.Services.Models
{
    public class PostModel : DefaultModel
    {
        public string PostCity { get; set; }
        public string PostCountry { get; set; }
        public string PostType { get; set; }
        public PostBureaus PostBureau { get; set; }
        //public string PostBureau { get; set; }
        public string Remark { get; set; }
    }
}
