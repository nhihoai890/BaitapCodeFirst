using Microsoft.AspNetCore.Mvc;
using BaitapCodeFirst.Data;
using BaitapCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

public class StudentController : Controller
{
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

   
    public IActionResult Index()
    {
        var students = _context.Students.Include(s => s.Course).ToList();
        return View(students);
    }

    
    public IActionResult Create()
    {
        ViewBag.Courses = _context.Courses.ToList();
        return View();
    }

  
    [HttpPost]
    public IActionResult Create(Student s)
    {
        if (ModelState.IsValid)
        {
            _context.Students.Add(s);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.Courses = _context.Courses.ToList();
        return View(s);
    }

    
    public IActionResult Edit(int id)
    {
        var student = _context.Students.Find(id);
        ViewBag.Courses = _context.Courses.ToList();
        return View(student);
    }

   
    [HttpPost]
    public IActionResult Edit(Student s)
    {
        if (ModelState.IsValid)
        {
            _context.Students.Update(s);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.Courses = _context.Courses.ToList();
        return View(s);
    }

   
    public IActionResult Delete(int id)
    {
        var student = _context.Students.Find(id);
        return View(student);
    }

    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var student = _context.Students.Find(id);
        _context.Students.Remove(student);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}