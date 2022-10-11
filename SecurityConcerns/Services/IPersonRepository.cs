using SecurityConcerns.Models.Entities;

namespace SecurityConcerns.Services;

public interface IPersonRepository
{
    Task<ICollection<Person>> ReadAllAsync();
    Task<Person> CreateAsync(Person person);
}
