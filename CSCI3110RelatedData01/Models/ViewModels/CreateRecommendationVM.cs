using CSCI3110RelatedData01.Models.Entities;

namespace CSCI3110RelatedData01.Models.ViewModels;

public class CreateRecommendationVM
{
    public Person? Person { get; set; }
    public Rating Rating { get; set; }
    public string Narrative { get; set; } = String.Empty;

    public Recommendation GetRecommendationInstance()
    {
        return new Recommendation
        {
            Id = 0,
            Rating = this.Rating,
            Narrative = this.Narrative
        };
    }
}
