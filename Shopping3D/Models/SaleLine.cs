using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping3D.Models
{
    public class SaleLine
    {
        public int Id { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public Product Product { get; set; }
        [Required]
        public Sale Sale { get; set; }
    }
}