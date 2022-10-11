using Microsoft.AspNetCore.Mvc;
using SecurityConcerns.Models.Entities;
using SecurityConcerns.Models.ViewModels;
using SecurityConcerns.Services;

namespace SecurityConcerns.Controllers;

public class PersonController : Controller
{
    private readonly IPersonRepository _personRepo;

    public PersonController(IPersonRepository personRepo)
    {
        _personRepo = personRepo;
    }

    public async Task<IActionResult> Index()
    {
        var people = await _personRepo.ReadAllAsync();
        return View(people);
    }

    public IActionResult CreateWithBind()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateWithBind(
        [Bind("FirstName,MiddleName,LastName,DateOfBirth")] Person person)
    {
        if (ModelState.IsValid)
        {
            await _personRepo.CreateAsync(person);
            return RedirectToAction("Index");
        }
        return View(person);
    }

    public IActionResult CreateWithVM()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateWithVM(CreatePersonVM personVM)
    {
        if (ModelState.IsValid)
        {
            var person = personVM.GetPersonInstance();
            await _personRepo.CreateAsync(person);
            return RedirectToAction("Index");
        }
        return View(personVM);
    }
}
