using DataModelingValidation.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DataModelingValidation.Controllers;

public class PersonController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create(CreatePersonVM personVM)
    {
        if (personVM.DateOfBirth > DateTime.Now)
        {
            ModelState.AddModelError(
                "DateOfBirth", 
                "The date of birth cannot be in the future.");
        }
        if (ModelState.IsValid)
        {
            // Not needed for this demonstration
            return RedirectToAction("Index");
        }
        return View(personVM);
    }
}
