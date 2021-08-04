namespace NewProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        public int cmtID { get; set; }

        public int userID { get; set; }

        public int newID { get; set; }

        [Required]
        public string contentComment { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateComment { get; set; }

        [StringLength(50)]
        public string userName { get; set; }

        public string Avt { get; set; }
        public int likecmttttt { get; set; }
    }
}
