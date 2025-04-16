using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            return View("Details", student);
        }
        return View(student);
    }

    public IActionResult MyRazorPage()
    {
        return View("~/Views/Home/MyRazorPage.cshtml");
    }
}
