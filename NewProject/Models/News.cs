namespace NewProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public News()
        {
            Images = new HashSet<Image>();
        }

        [Key]
        public int newID { get; set; }

        public int userID { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string category { get; set; }

        [Required]
        public string imageNew { get; set; }

        [Required]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime datePost { get; set; }

        public int viewCount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Images { get; set; }
    }
}
