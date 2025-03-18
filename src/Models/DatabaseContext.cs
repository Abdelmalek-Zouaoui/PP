using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using App.Models; // Add this to reference the User and Thesis classes

namespace App.Models
{
    public class DatabaseContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Thesis> Theses { get; set; }

     
          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                 optionsBuilder.UseMySql("Server=localhost;Database=gestion_theses;User=root;Password=yourpassword;",
                new MySqlServerVersion(new Version(8, 0, 30)));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between User and Thesis
                 modelBuilder.Entity<Thesis>()
                 .HasOne(t => t.User) // A Thesis has one User
                .WithMany() // A User can have many Theses
                .HasForeignKey(t => t.UserId); // Foreign key is UserId
        }
    }
}