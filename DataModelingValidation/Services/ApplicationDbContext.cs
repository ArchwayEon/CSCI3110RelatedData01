using DataModelingValidation.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataModelingValidation.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
               .HasKey(c => new { c.Code, c.Number });
    }

    public DbSet<Person> People => Set<Person>();
    public DbSet<Course> Courses => Set<Course>();
}
