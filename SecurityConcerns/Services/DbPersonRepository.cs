using Microsoft.EntityFrameworkCore;
using SecurityConcerns.Models.Entities;

namespace SecurityConcerns.Services;

public class DbPersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _db;

    public DbPersonRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Person> CreateAsync(Person person)
    {
        await _db.People.AddAsync(person);
        await _db.SaveChangesAsync();
        return person;
    }

    public async Task<ICollection<Person>> ReadAllAsync()
    {
        return await _db.People.ToListAsync();
    }
}
