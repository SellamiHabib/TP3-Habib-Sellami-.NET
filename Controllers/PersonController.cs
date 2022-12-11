using Microsoft.AspNetCore.Mvc;
using TP3_Habib_Sellami.Models;

namespace TP3_Habib_Sellami.Controllers;

public class Person : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    [Route("/Personne/all")] // localhost:5000/Personne/all
    public IActionResult GetAll()
    {
        return View(Personal_info.GetAllPerson());
    }
}
