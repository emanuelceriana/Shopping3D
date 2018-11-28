using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shopping3D.Models
{
    public class SaleLine
    {
        public SaleLine(Product Product, int ProductQuantity, decimal SubTotal) {

            this.ProductId = Product.Id;
            this.Product = Product;
            this.ProductQuantity = ProductQuantity;
            this.SubTotal = SubTotal;
        }

        public int Id { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        [Required]
        public decimal SubTotal { get; set; }

        [ForeignKey ("Product")]
        public int ProductId { get; set; }
        
        public Product Product { get; set; }

        [Required]
        public Sale Sale { get; set; }
    }
}