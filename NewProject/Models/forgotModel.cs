using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class forgotModel
    {
        [Required(ErrorMessage = "this Field is required")]
        public string username { get; set; }
        [Required(ErrorMessage = "this Field is required")]
        public string password { get; set; }
        [Required(ErrorMessage = "this Field is required")]
        public string securityAnswer { get; set; }
        public string repassword { get; set; }
    }
}