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
        public string FristName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

    }
}