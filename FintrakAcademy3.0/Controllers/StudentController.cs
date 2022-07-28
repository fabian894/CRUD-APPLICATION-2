using FintrakAcademy3._0.Data;
using FintrakAcademy3._0.Models;
using Microsoft.AspNetCore.Mvc;

namespace FintrakAcademy3._0.Controllers;

public class StudentController : Controller
{
    private readonly ApplicationDbContext _db;

    public StudentController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
{
        IEnumerable<Student> objStudentList = _db.Students.ToList();
    return View(objStudentList);
}
    //GET
    public IActionResult Create()
    {
       
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student obj)
    {
        if(obj.FirstName == obj.LastName )
          
            {
                ModelState.AddModelError("FirstName", "The FirstName cannot exactly match the Last Name.");
        }
        if (ModelState.IsValid)
        {
            _db.Students.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "student created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {

            return NotFound();
        }
        var StudentFromDb = _db.Students.Find(id);
        
        if (StudentFromDb == null)
        {
            return NotFound();
        }
        return View(StudentFromDb);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Student obj)
    {
        if (obj.FirstName == obj.LastName)

        {
            ModelState.AddModelError("FirstName", "The first name cannot exactly match the last name.");
        }
        if (ModelState.IsValid)
        {
            _db.Students.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "student updated successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {

            return NotFound();
        }
        var StudentFromDb = _db.Students.Find(id);

        if (StudentFromDb == null)
        {
            return NotFound();
        }
        return View(StudentFromDb);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
       var obj = _db.Students.Find(id);
        if (obj == null)
        {
            return NotFound();
        }
            _db.Students.Remove(obj);
            _db.SaveChanges();
        TempData["success"] = "student deleted successfully";
        return RedirectToAction("Index");
       
    }


}
