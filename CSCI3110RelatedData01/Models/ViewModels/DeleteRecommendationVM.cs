using CSCI3110RelatedData01.Models.Entities;

namespace CSCI3110RelatedData01.Models.ViewModels;

public class DeleteRecommendationVM
{
    public Person? Person { get; set; }
    public int Id { get; set; }
    public Rating Rating { get; set; }
    public string Narrative { get; set; } = String.Empty;
}
