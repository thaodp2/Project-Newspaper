namespace NewProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        public int userID { get; set; }
        [Required(ErrorMessage = "this Field is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "this Field is required")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string password { get; set; }
        [Required(ErrorMessage = "this Field is required")]
        public string name { get; set; }
        [DefaultValue("")]
        public string avatar { get; set; }
        [Required(ErrorMessage = "this Field is required")]
        public string gmail { get; set; }
        [Required(ErrorMessage = "this Field is required")]
        public System.DateTime DOB { get; set; }
        [Required(ErrorMessage = "this Field is required")]
        public string securityAnswer { get; set; }
        [DefaultValue("false")]
        public bool isAdmin { get; set; }
        [Required(ErrorMessage = "this Field is required")]
        [NotMapped]
        [DataType(DataType.Password)]

        public string repassword { get; set; }
    }
}
