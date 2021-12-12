using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unsalted.Models
{
    public class Review
    {
        public int ID { get; set; }
        public int FoodID { get; set; }
        public string User { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        public virtual Food Food { get; set; }
    }
}