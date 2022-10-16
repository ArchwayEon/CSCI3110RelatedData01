using CSCI3110RelatedData01.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSCI3110RelatedData01.Services;

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

    public async Task<Recommendation> CreateRecommendationAsync(
        int personId, Recommendation recommendation)
    {
        var person = await ReadAsync(personId);
        if (person != null)
        {
            person.Recommendations.Add(recommendation);
            recommendation.Person = person;
            await _db.SaveChangesAsync();
        }
        return recommendation;
    }

    public async Task DeleteRecommendationAsync(
        int personId, int recommendationId)
    {
        var person = await ReadAsync(personId);
        if (person != null)
        {
            var recommendation = person.Recommendations
               .FirstOrDefault(r => r.Id == recommendationId);
            if (recommendation != null)
            {
                person.Recommendations.Remove(recommendation);
                await _db.SaveChangesAsync();
            }
        }
    }

    public async Task<ICollection<Person>> ReadAllAsync()
    {
        return await _db.People
            .Include(p => p.Recommendations)
            .ToListAsync();
    }

    public async Task<Person?> ReadAsync(int id)
    {
        var person = await _db.People.FindAsync(id);
        // Use explicit loading since using Find
        if (person != null)
        {
            _db.Entry(person)
              .Collection(p => p.Recommendations)
              .Load();
        }
        return person;
    }

    public async Task UpdateRecommendationAsync(
        int personId, Recommendation recommendation)
    {
        var person = await ReadAsync(personId);
        if (person != null)
        {
            var recommendationToUpdate = person.Recommendations
                .FirstOrDefault(r => r.Id == recommendation.Id);
            if (recommendationToUpdate != null)
            {
                recommendationToUpdate.Narrative = recommendation.Narrative;
                recommendationToUpdate.Rating = recommendation.Rating;
                await _db.SaveChangesAsync();
            }
        }
    }
}
