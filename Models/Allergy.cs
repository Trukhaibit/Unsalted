using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unsalted.Models
{
    public class Allergy
    {
        public Allergy()
        {
            Food = new HashSet<Food>();
        }
        public int ID { get; set; }
        
        public string Allergen { get; set; }
        public string Examples { get; set; }
        public string Reactions { get; set; }

        public virtual ICollection<Food> Food { get; set; }
    }
}