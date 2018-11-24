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
             Description = "This is My eighth of dragon child and Sister to the Seven. It more focused on stablize ball and joints strength and prevent ball's broken off. by chop off the ball it self from parts to prevent getting break off. but, it is pack of experimental tricks, you may need to glue the some parts together. The head it self is same as Seven as i was had no idea for head when i started develope this dragon.",
             Price = 450,
             Currency = 0,
             Image = "~/Pictures/Products/p1.jpg",
             Quantity = 6
         },

         new Product()
         {
             Id = 2,
             Name = "Florero Especial",
             Description = "Just a couple of modifiers to give Honeycomb vase(by radus) more stable bottom. Also i think it looks more organic. Done in Blender 3d, .blend file is attached.",
             Price = 250,
             Currency = 0,
             Image = "~/Pictures/Products/p2.jpg",
             Quantity = 25
         },

         new Product()
         {
             Id = 3,
             Name = "Dinosaurio Mágico",
             Description = "My print of Kirbs' model was not very kid-proof: one of the links broke after some rough handling. Hence I made all links more robust. This means this model can probably be printed even smaller than the original ones before the links become too weak. Of course you can also scale it up at will.",
             Price = 400,
             Currency = 0,
             Image = "~/Pictures/Products/p3.jpg",
             Quantity = 3
         },

         new Product()
         {
             Id = 4,
             Name = "Lámpara Brillante",
             Description = "A big cellular thing. Use this as a lampshade for an LED light or as a sculpture. Many people have printed the bracelets I uploaded so I decided to give you something bigger. Here's the model on Cell Cycle:",
             Price = 320,
             Currency = 0,
             Image = "~/Pictures/Products/p5.jpg",
             Quantity = 10
         },

         new Product()
         {
             Id = 5,
             Name = "Elefante Gigante",
             Description = "We created this cute little articulated elephant last month for our friends in Nante, at IRT Jules Verne (France). Their city is well known for their giant puppets.The most famous one is a huge robotic elephant, the size of a building. Since they bought a lot of material from le FabShop, including a ton of MakerBots, our creative director, Samuel N.Bernier designed this little toy to be used as a goodie. It had a great success, so we decided to share it with you.",
             Price = 600,
             Currency = 0,
             Image = "~/Pictures/Products/p6.jpg",
             Quantity = 2
         }
         );

        }
    }
}
