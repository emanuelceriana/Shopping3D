namespace Shopping3D.Migrations
{
    using Shopping3D.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shopping3D.Models.DbContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Shopping3D.Models.DbContexto context)
        {
            context.Products.AddOrUpdate(x => x.Id,
        
         new Product()
         {
             Id = 1,
             Name = "Dragón Fantástico",
             Description = "",
             Price = 450,
             Currency = 0,
             Image = "~/Pictures/Products/p1.jpg",
             Quantity = 6
         },

         new Product()
         {
             Id = 2,
             Name = "Florero Especial",
             Description = "",
             Price = 250,
             Currency = 0,
             Image = "~/Pictures/Products/p2.jpg",
             Quantity = 25
         },

         new Product()
         {
             Id = 3,
             Name = "Dinosaurio Mágico",
             Description = "",
             Price = 400,
             Currency = 0,
             Image = "~/Pictures/Products/p3.jpg",
             Quantity = 3
         },

         new Product()
         {
             Id = 4,
             Name = "Lámpara Brillante",
             Description = "",
             Price = 320,
             Currency = 0,
             Image = "~/Pictures/Products/p5.jpg",
             Quantity = 10
         },

         new Product()
         {
             Id = 5,
             Name = "Elefante Gigante",
             Description = "",
             Price = 600,
             Currency = 0,
             Image = "~/Pictures/Products/p6.jpg",
             Quantity = 2
         }
         );

        }
    }
}
