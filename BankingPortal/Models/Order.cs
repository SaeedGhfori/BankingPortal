using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarinPal_MVC.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int Sum { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsFinaly { get; set; }


    }
}