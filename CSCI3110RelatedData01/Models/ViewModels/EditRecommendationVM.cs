using CSCI3110RelatedData01.Models.Entities;

namespace CSCI3110RelatedData01.Models.ViewModels;

public class EditRecommendationVM
{
    public Person? Person { get; set; }
    public int Id { get; set; }
    public Rating Rating { get; set; }
    public string Narrative { get; set; } = String.Empty;

    public Recommendation GetRecommendationInstance()
    {
        return new Recommendation
        {
            Id = this.Id,
            Rating = this.Rating,
            Narrative = this.Narrative
        };
    }
}
