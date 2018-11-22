using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping3D.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
    }
}