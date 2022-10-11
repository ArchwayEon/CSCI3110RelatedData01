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
            return RedirectToAction("Index", "Person");
        }
        recommendationVM.Person = await _personRepo.ReadAsync(personId);
        return View(recommendationVM);
    }

}
