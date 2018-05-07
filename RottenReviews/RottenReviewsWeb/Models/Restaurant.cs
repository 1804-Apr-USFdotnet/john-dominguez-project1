using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RottenReviewsWeb.Models
{
    [Table("Restaurant", Schema = "Restaurant")]
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Restaurant Name Required")]
        public string Name { get; set; }
        
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Url]
        public string Website { get; set; } 

        //Foreign Key Relationship
        public virtual ICollection<Review> Reviews { get; set; }

        //DateTime
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        //Not Mapped
        [NotMapped]
        public double Rating
        {
            get
            {
                return Reviews.Sum(x => x.Rating);
            }
        }
    }
}