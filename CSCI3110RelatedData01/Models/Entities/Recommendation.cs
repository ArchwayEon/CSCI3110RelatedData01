using System.ComponentModel.DataAnnotations;

namespace CSCI3110RelatedData01.Models.Entities;

public class Recommendation
{
    public int Id { get; set; }
    public Rating Rating { get; set; }
    [StringLength(512)]
    public string Narrative { get; set; } = String.Empty;
    public int PersonId { get; set; }
    public Person? Person { get; set; }
}
