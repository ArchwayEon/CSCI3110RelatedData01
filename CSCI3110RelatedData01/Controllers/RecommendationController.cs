using CSCI3110RelatedData01.Models.Entities;
using CSCI3110RelatedData01.Models.ViewModels;
using CSCI3110RelatedData01.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSCI3110RelatedData01.Controllers;

public class RecommendationController : Controller
{
    private readonly IPersonRepository _personRepo;

    public RecommendationController(IPersonRepository personRepo)
    {
        _personRepo = personRepo;
    }

    public async Task<IActionResult> Create([Bind(Prefix = "id")] int personId)
    {
        var person = await _personRepo.ReadAsync(personId);
        if (person == null)
        {
            return RedirectToAction("Index", "Person");
        }
        var recommendationVM = new CreateRecommendationVM
        {
            Person = person
        };
        return View(recommendationVM);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        int personId, CreateRecommendationVM recommendationVM)
    {
        if (ModelState.IsValid)
        {
            var recommendation = recommendationVM.GetRecommendationInstance();
            await _personRepo.CreateRecommendationAsync(personId, recommendation);
            return RedirectToAction("Details", "Person", new { id = personId });
        }
        recommendationVM.Person = await _personRepo.ReadAsync(personId);
        return View(recommendationVM);
    }

    public async Task<IActionResult> Edit(
        [Bind(Prefix = "id")] int personId, int recId)
    {
        var person = await _personRepo.ReadAsync(personId);
        if (person == null)
        {
            return RedirectToAction("Index", "Person");
        }
        var recommendation = 
            person.Recommendations.FirstOrDefault(r => r.Id == recId);
        if (recommendation == null)
        {
            return RedirectToAction(
                "Details", "Person", new { id = personId });
        }
        var model = new EditRecommendationVM
        {
            Person = person,
            Id = recommendation.Id,
            Rating = recommendation.Rating,
            Narrative = recommendation.Narrative
        };
        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int personId, EditRecommendationVM recommendationVM)
    {
        if (ModelState.IsValid)
        {
            var recommendation = 
                recommendationVM.GetRecommendationInstance();
            await _personRepo.UpdateRecommendationAsync(
                personId, recommendation);
            return RedirectToAction("Details", "Person", new { id = personId });
        }
        recommendationVM.Person = await _personRepo.ReadAsync(personId);
        return View(recommendationVM);
    }

    public async Task<IActionResult> Delete(
        [Bind(Prefix = "id")] int personId, int recId)
    {
        var person = await _personRepo.ReadAsync(personId);
        if (person == null)
        {
            return RedirectToAction("Index", "Person");
        }
        var recommendation =
            person.Recommendations.FirstOrDefault(r => r.Id == recId);
        if (recommendation == null)
        {
            return RedirectToAction(
                "Details", "Person", new { id = personId });
        }
        var model = new DeleteRecommendationVM
        {
            Person = person,
            Id = recommendation.Id,
            Rating = recommendation.Rating,
            Narrative = recommendation.Narrative
        };
        return View(model);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, int personId)
    {
        await _personRepo.DeleteRecommendationAsync(personId, id);
        return RedirectToAction("Details", "Person", new { id = personId });
    }

}
