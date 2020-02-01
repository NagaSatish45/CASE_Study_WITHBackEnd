using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Models
{
    public class Items
    {
        [Key]
        public int iid { get; set; }
        public double price { get; set; }
        public string itemname { get; set; }
        public string description { get; set; }
        public int stock_number { get; set; }
        public string remarks { get; set; }



        public Items(int iid, double price, string itemname, string description, int stock_number, string remarks)
        {
            this.iid = iid;
            this.price = price;
            this.itemname = itemname;
            this.description = description;
            this.stock_number = stock_number;
            this.remarks = remarks;
        }


    }
}
