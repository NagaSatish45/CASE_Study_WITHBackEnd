using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Models
{
    public class SubCategory : Category
    {
        [Key]
        public  int sub_id { get; set; }
        public  string sub_name { get; set; }
        public  float gST { get; set; }



       
    }
}
