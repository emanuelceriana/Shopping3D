using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shopping3D.Models
{
    public class DbContexto : DbContext
    {
        public DbContexto() : base("cn")
        {

        }

        //public DbSet<Producto> Productos {get;set;}
    }
}