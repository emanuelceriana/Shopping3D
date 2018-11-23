using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping3D.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public ICollection<Sale> Sale { get; set; }
    }
}