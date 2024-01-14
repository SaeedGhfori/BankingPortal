using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingPortalCore.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public int Sum { get; set; }

        public bool IsFinaly { get; set; }



        public List<OrderDetail> OrderDetails { get; set; }
    }
}
