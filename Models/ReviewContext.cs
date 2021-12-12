using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Unsalted.Models;

namespace Unsalted.Models
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options)
            : base(options)
        { }
        public DbSet<Allergy> Allergy { get; set; }
        public DbSet<Diet> Diet { get; set; }
        public DbSet<Food> Food { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergy>().HasData(
                new Allergy
                { 
                    ID = 1,
                    Allergen = "Gluten",
                    Examples = "Bread, Wheat, Cereal, etc.",
                    Reactions = "Stomach ache, Rash, etc."
                }
            );
            modelBuilder.Entity<Diet>().HasData(
                new Diet
                {
                    ID = 1,
                    Type = "Kosher",
                    Explanation = "In accordance with Jewish Dietary Law",
                }
            );
            modelBuilder.Entity<Food>().HasData(
                new Food
                {
                    ID = 1,
                    Item = "Spaghetti and Meatballs",
                    Description = "A traditional Italian dish, although the meatballs were added by the Swedes.",
                    DietID = 1,
                    AllergyID = 1
                }
            );
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    ID = 1
                }
            );

            //Composite key
            modelBuilder.Entity<Food>().HasKey(d => new { d.DietID, d.AllergyID });
            modelBuilder.Entity<Food>().HasOne(dl => dl.Diet)
                .WithMany(d => d.Food).HasForeignKey(dl => dl.DietID);
            modelBuilder.Entity<Food>().HasOne(dl => dl.Allergen)
                .WithMany(d => d.Food).HasForeignKey(dl => dl.AllergyID);

            modelBuilder.Entity<Review>().HasKey(d => new { d.FoodID});
            modelBuilder.Entity<Review>().HasOne(dl => dl.Food)
                .WithMany(d => d.Review).HasForeignKey(dl => dl.FoodID);
        }



        public DbSet<Unsalted.Models.Review> Review { get; set; }
    }
}
