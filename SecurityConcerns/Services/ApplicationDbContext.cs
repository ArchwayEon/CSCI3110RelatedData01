using Microsoft.EntityFrameworkCore;
using SecurityConcerns.Models.Entities;

namespace SecurityConcerns.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> People => Set<Person>();
}
