using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerList.Models
{
    public class Customer
    {



        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FristName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

    }
}