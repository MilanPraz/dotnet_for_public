using Microsoft.AspNetCore.Mvc;
using WebApp3ByMilanprajapati.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApp3ByMilanprajapati.Controllers
{
    public class StudentController : Controller
    {
        // Static list to simulate the database
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John Doe", Age = 20, Faculty = "Computer Science" },
            new Student { Id = 2, Name = "Jane Smith", Age = 22, Faculty = "Mathematics" },
            new Student { Id = 3, Name = "Sam Wilson", Age = 21, Faculty = "Physics" }
        };

        // GET: Student/Index
        public IActionResult Index()
        {
            return View(students);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View(new Student());
        }

        // POST: Student/Create
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            // Generate new Id
            student.Id = students.Max(s => s.Id) + 1;
            students.Add(student);

            return RedirectToAction("Index");
        }

        // GET: Student/Edit/5
        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent == null)
                return NotFound();

            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;
            existingStudent.Faculty = student.Faculty;

            return RedirectToAction("Index");
        }

        // GET: Student/Delete/5
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            students.Remove(student);

            return RedirectToAction("Index");
        }
    }
}
