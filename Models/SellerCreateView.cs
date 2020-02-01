﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Models
{
    public class SellerCreateView
    {
        [Key]
        public int SID { get; set; }
        public string Sname { get; set; }
        public string Companyname { get; set; }
        public string Semail { get; set; }
        public string Spassword { get; set; }
        public string Saddress { get; set; }
        public int Contactno { get; set; }
        public IFormFile Photopath { get; set; }

    }
}
