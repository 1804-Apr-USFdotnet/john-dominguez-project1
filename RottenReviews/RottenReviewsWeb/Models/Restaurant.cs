using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.Ajax.Utilities;

namespace RottenReviewsWeb.Models
{
    [Table("Restaurant", Schema = "Restaurant")]
    public class Restaurant : IComparable
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
        public Nullable<DateTime> Created { get; set; }
        public Nullable<DateTime> Modified { get; set; }

        //Not Mapped
        [NotMapped]
        public double? Rating
        {
            get
            {
                if (Reviews.Count == 0) return null;
                return Reviews.Sum(x => x.Rating);
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Restaurant otherTemperature = obj as Restaurant;
            if (otherTemperature != null)
                return this.Name.CompareTo(otherTemperature.Name);
            else
                throw new ArgumentException("Object is not a Restaurant");
        }
    }
}