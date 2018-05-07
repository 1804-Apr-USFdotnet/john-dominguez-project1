using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RottenReviewsWeb.Models
{
    [Table("Review", Schema = "Restaurant")]
    public class Review
    {
        //Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        //Properties
        [Required(ErrorMessage = "Rating Required")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1-5")]
        public int Rating { get; set; }

        [StringLength(400, ErrorMessage = "Character limit of 400 reached")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        //Foreign Key
        public virtual Restaurant Restaurant { get; set; }

        //DateTime
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}