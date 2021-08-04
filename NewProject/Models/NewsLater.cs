namespace NewProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsLater")]
    public partial class NewsLater
    {
        public int id { get; set; }

        public int newID { get; set; }

        public int userID { get; set; }
    }
}
