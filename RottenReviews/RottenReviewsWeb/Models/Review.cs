using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RottenReviewsWeb.Models
{
    [Table("Review", Schema = "Restaurant")]
    public class Review : IComparable
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

        [Required(ErrorMessage = "Username is Required")]
        public string Author { get; set; }

        [Required]
        public int RestaurantID { get; set; }

        //Foreign Key
        public virtual Restaurant Restaurant { get; set; }

        //DateTime
        public Nullable<DateTime> Created { get; set; }
        public Nullable<DateTime> Modified { get; set; }

        //
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Restaurant otherTemperature = obj as Restaurant;
            if (otherTemperature != null)
                return this.Created.Value.CompareTo(otherTemperature.Created.Value);
            else
                throw new ArgumentException("Object is not a Review");
        }
    }
    
}