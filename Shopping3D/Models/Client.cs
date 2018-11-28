using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping3D.Models
{
    public class Client
    {
        public Client()
        {
        }

        public Client(string Email) {
            this.Email = Email;
        }

        public int Id { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(50)]
        public string Email { get; set; }

        public ICollection<Sale> Sale { get; set; }
    }
}