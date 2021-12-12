using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unsalted.Models
{
    public class Diet
    {
        public Diet()
        {
            Food = new HashSet<Food>();
        }
        public int ID { get; set; }

        public string Type { get; set; }
        public string Explanation { get; set; }

        public virtual ICollection<Food> Food { get; set; }

    }
}