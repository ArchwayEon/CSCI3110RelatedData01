using DataModelingValidation.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace DataModelingValidation.Models.ViewModels;

public class CreatePersonVM
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
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

