using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FlavorFinder.Models.Entities;

namespace FlavorFinder.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<RecipeEntity> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecipeEntity>(entity =>
            {
                entity.Property(r => r.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

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