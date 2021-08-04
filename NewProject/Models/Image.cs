namespace NewProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        public int id { get; set; }

        public int idNews { get; set; }

        public string linkImg { get; set; }

        public virtual News News { get; set; }
    }
}
