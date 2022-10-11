using CSCI3110RelatedData01.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSCI3110RelatedData01.Controllers;

public class PersonController : Controller
{
    private readonly IPersonRepository _personRepo;

    public PersonController(IPersonRepository personRepo)
    {
        _personRepo = personRepo;
    }

    public async  Task<IActionResult> Index()
    {
        var people = await _personRepo.ReadAllAsync();
        return View(people);
    }

    public async Task<IActionResult> Details(int id)
    {
        var person = await _personRepo.ReadAsync(id);
        if(person == null)
        {
            return RedirectToAction("Index");
        }
        return View(person);
    }
}
