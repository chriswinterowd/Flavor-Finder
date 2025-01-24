using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FlavorFinder.Models;

namespace FlavorFinder.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Title)
                    .IsRequired();

                entity.Property(r => r.Cuisines)
                    .HasColumnType("jsonb");

                entity.Property(r => r.DishTypes)
                    .HasColumnType("jsonb");

                entity.Property(r => r.ExtendedIngredients)
                    .HasColumnType("jsonb");

                entity.Property(r => r.AnalyzedInstructions)
                    .HasColumnType("jsonb");
            });
        }
    }
}