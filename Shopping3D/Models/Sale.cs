using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping3D.Models
{
    public class Sale
    {
        /*public Sale(Client Client, decimal Total, DateTime Date) {
            this.Client = Client;
            this.Total = Total;
            this.Date = Date;
        }*/

        public int Id { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public ICollection<SaleLine> SaleLine { get; set; }
        [Required]
        public Client Client { get; set; }
    }
}