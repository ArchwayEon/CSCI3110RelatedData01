using System.ComponentModel.DataAnnotations;

namespace DataModelingValidation.Models.Entities;

public class Course
{
    [StringLength(4)]
    public string Code { get; set; } = String.Empty;
    [StringLength(4)]
    public string Number { get; set; } = String.Empty;
    public int CreditHours { get; set; }
}
