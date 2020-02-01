using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Models
{
    public class Buyer
    {
        [Key]
        public int BId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public int Phoneno { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
