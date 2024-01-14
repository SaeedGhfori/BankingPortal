using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZarinPal_MVC.Models
{
    public class ZarinPal_MVCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ZarinPal_MVCContext() : base("name=ZarinPal_MVCContext")
        {
        }

        public System.Data.Entity.DbSet<ZarinPal_MVC.Models.Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
