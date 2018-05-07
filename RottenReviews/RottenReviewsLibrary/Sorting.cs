using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottenReviewsLibrary
{
    public class Sorting
    {
        public List<T> SortAscending<T>(List<T> list, string attribute="Name")
        {
            var property = typeof(T).GetProperty(attribute);
            if (property == null) return new List<T>();
            return list.OrderBy(item => (string) property.GetValue(item, null)).ToList();
        }

        public List<T> SortDescending<T>(List<T> list, string attribute = "Name")
        {
            var property = typeof(T).GetProperty(attribute);
            if (property == null) return new List<T>();
            return list.OrderByDescending(item => (string)property.GetValue(item, null)).ToList();
        }
    }
}
