
using CSCI3110RelatedData01.Models.Entities;

namespace CSCI3110RelatedData01.Services;

public interface IPersonRepository
{
    Task<ICollection<Person>> ReadAllAsync();
    Task<Person> CreateAsync(Person person);
    Task<Person?> ReadAsync(int id);

    Task<Recommendation> CreateRecommendationAsync(
        int personId, Recommendation recommendation);
}
