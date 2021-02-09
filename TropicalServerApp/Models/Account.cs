using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TropicalServerApp.Models
{
    public class Account
    {
        [Required(ErrorMessage ="UserID Required")]
        public string UserID { get; set; }

        [Required(ErrorMessage ="Password Required")]
        [DataType("password")]
        public string Password { get; set; }

        public string EmailID { get; set; }
    }
}