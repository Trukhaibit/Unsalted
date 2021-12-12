using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unsalted.Models
{
    public class Food
    {
        public int ID { get; set; }

        public string Item { get; set; }
        public string Description { get; set; }
        public int DietID { get; set; }
        public int AllergyID { get; set; }
        
        public virtual Diet Diet { get; set; }
        public virtual Allergy Allergen { get; set; }

        public virtual ICollection<Review> Review { get; set; }
    }
}