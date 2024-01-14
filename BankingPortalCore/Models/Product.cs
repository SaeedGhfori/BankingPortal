using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingPortalCore.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string ImageName { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
