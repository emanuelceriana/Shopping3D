using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shopping3D.Models
{
    public class DbContexto : DbContext
    {
        public DbContexto() 
            :base("Shopping3D")
        {

        }

        public DbSet<Product> Products { get; set;}
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleLine> SaleLines { get; set; }
    }
}