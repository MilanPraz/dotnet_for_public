using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace VehicleRegistrationApp.Controllers
{
    public class VehicleController : Controller
    {
        // Static list of vehicles
        private static List<dynamic> vehicles = new List<dynamic>
        {
            new { Id = 1, RegistrationNumber = "ABC123", Make = "Toyota", Model = "Camry", Year = 2015, OwnerName = "John Doe" },
            new { Id = 2, RegistrationNumber = "XYZ456", Make = "Honda", Model = "Civic", Year = 2018, OwnerName = "Jane Smith" },
            new { Id = 3, RegistrationNumber = "LMN789", Make = "Ford", Model = "Mustang", Year = 2020, OwnerName = "Emily Johnson" }
        };

        public IActionResult Index()
        {
            return View(vehicles);
        }

        public IActionResult Details(int id)
        {
            var vehicle = vehicles.Find(v => v.Id == id);
            return View(vehicle);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string RegistrationNumber, string Make, string Model, int Year, string OwnerName)
        {
            var vehicle = new { Id = vehicles.Count + 1, RegistrationNumber = RegistrationNumber, Make = Make, Model = Model, Year = Year, OwnerName = OwnerName };
            vehicles.Add(vehicle);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vehicle = vehicles.Find(v => v.Id == id);
            return View(vehicle);
        }

        [HttpPost]
        public IActionResult Edit(int Id, string RegistrationNumber, string Make, string Model, int Year, string OwnerName)
        {
            var vehicle = vehicles.Find(v => v.Id == Id);
            if (vehicle != null)
            {
                vehicles.Remove(vehicle);
                vehicles.Add(new { Id = Id, RegistrationNumber = RegistrationNumber, Make = Make, Model = Model, Year = Year, OwnerName = OwnerName });
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var vehicle = vehicles.Find(v => v.Id == id);
            if (vehicle != null)
            {
                vehicles.Remove(vehicle);
            }

            return RedirectToAction("Index");
        }
    }
}
