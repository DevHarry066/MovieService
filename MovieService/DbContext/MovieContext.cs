using Microsoft.EntityFrameworkCore;
using MovieService.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace YourNamespace.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Casts { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Movie entity
            modelBuilder.Entity<Movie>()
                .HasKey(m => m.Id); // Primary key

            // Configure Cast entity
            modelBuilder.Entity<Cast>()
                .HasKey(c => c.Id); // Primary key

        }
    }
}
