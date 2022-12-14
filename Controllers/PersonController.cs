using Microsoft.AspNetCore.Mvc;
using TP3_Habib_Sellami.Models;

namespace TP3_Habib_Sellami.Controllers;

[Route("[controller]")]
public class Person : Controller
{

    [HttpGet]
    [Route("/")]
    public IActionResult AllPersons()
    {

        Personal_info personal_Info = new Personal_info();
        List<Models.Person> allPersons = personal_Info.GetAllPerson();
        return View(allPersons);
    }


    [HttpGet]
    [Route("/Person/{userID:int}")]
    public IActionResult PersonDetails(int userID)
    {
        Personal_info personal_Info = new Personal_info();
        Models.Person resultUser = personal_Info.GetPerson(userID);
        ViewBag.person = resultUser;

        return View(resultUser);
    }

    [HttpGet]
    [Route("/Person/search")]
    public IActionResult SearchPerson()
    {
        return View();
    }

    [HttpPost]
    [Route("/Person/SearchHandler")]
    public IActionResult SearchHandler(PersonDTO formCentent)
    {
        string firstName = formCentent.FirstName;
        string country = formCentent.Country;

        Personal_info request_data = new Personal_info();
        Models.Person resulted_data = request_data.GetPersonBySearch(firstName, country);
        return Redirect("/Person/"+resulted_data.Id);
    }
}
