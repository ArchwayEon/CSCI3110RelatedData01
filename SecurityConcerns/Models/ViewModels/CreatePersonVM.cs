using SecurityConcerns.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace SecurityConcerns.Models.ViewModels;

public class CreatePersonVM
{
    public string FirstName { get; set; } = String.Empty;
    public string MiddleName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    public Person GetPersonInstance()
    {
        return new Person
        {
            Id = 0,
            UserName = String.Empty,
            FirstName = this.FirstName,
            MiddleName = this.MiddleName,
            LastName = this.LastName,
            DateOfBirth = this.DateOfBirth
        };
    }
}

