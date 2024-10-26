using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Web_Double.Context;

namespace Web_Double.Models
{
    public class DataModel
    {
        public List<Tshirt> Tshirts { get; set; }
        public List<PoloShirt> PoloShirts { get; set; }
        public List<Aokhoac> Aokhoacs { get; set; }
        public List<Quan> Quans { get; set; }
        public List<Somi> Somis { get; set; }
        public List<Hoodee> Hoodees { get; set; }
        public List<Phukien> Phukiens { get; set; }
    }
    public class ProductDetailViewModel
    {
        //public Tshirts Tshirt { get; set; }
        //public PoloShirt PoloShirt { get; set; }
        public List<Shirt> shirts { get; set; }
        public List<User> users { get; set; }
        public dynamic Product { get; set; }
        public int UserId { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}