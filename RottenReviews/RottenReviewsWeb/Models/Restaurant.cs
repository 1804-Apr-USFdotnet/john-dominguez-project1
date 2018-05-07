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
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Invalid Zipcode(AreaCode")]
        [Required(ErrorMessage = "Zipcode(AreaCode is Required")]
        public string Zipcode { get; set; }

        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Invalid Phone")]
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