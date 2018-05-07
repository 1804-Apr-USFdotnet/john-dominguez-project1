using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RottenReviewsWeb.DAL
{
    public class BaseEntity
    {
        DateTime Created { get; set; }
        DateTime? Modified { get; set; }
    }
}