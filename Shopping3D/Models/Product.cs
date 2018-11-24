using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping3D.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Currency { get; set; }
        [StringLength(50)]
        public string Image{ get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}