using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp2ByMilanPrajapati.Models;

namespace WebApp2ByMilanPrajapati.Controllers;

using WebApp2ByMilanPrajapati.Services;

public class HomeController : Controller
{
    private readonly IGreetingService _greetingService;

    public HomeController(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    public IActionResult Index()
    {
        ViewBag.Message = _greetingService.Greet();
        return View();
    }
}
