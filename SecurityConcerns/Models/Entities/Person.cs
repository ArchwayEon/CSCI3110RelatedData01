using System.ComponentModel.DataAnnotations;

namespace SecurityConcerns.Models.Entities;

public class Person
{
    public int Id { get; set; }
    public string UserName { get; set; } = String.Empty;
    public string FirstName { get; set; } = String.Empty;
    public string MiddleName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
}
