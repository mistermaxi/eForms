using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace eForms.Domain.Models
{
    public class Posts : DefaultModel
    {
        public string PostCity { get; set; }
        public string PostCountry { get; set; }
        public string PostType { get; set; }
        public string PostBureau { get; set; }
        public string Remark { get; set; }
    }
}
