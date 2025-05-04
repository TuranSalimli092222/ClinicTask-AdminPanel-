using ClinicTask.DAL;
using ClinicTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicTask.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
	private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
	{
		List<Department> departments;
		departments = _context.Departments.Include(d=>d.Doctors).ToList();
		return View(departments);
	}
	public IActionResult Create()
	{ 
	return View();
	}

	[HttpPost]
	public IActionResult Create(Department department)
	{
        if (!ModelState.IsValid)
        {
            return BadRequest("Samething wnet wrong!");
        }
        _context.Departments.Add(department);

		_context.SaveChanges();

		return RedirectToAction(nameof(Index));
	}

	public IActionResult Delete(int id)
	{ 
		Department department = _context.Departments.Find(id);
		if (department == null) {return NotFound("Department could not found");}
		_context.Departments.Remove(department);
		_context.SaveChanges();
		return RedirectToAction(nameof(Index));
	}
    public IActionResult Update(int id)
    {
        var department = _context.Departments.FirstOrDefault(d => d.Id == id);
        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }

    // POST: Department/Edit
    [HttpPost]
    public IActionResult Update(Department department)
    {
        if (!ModelState.IsValid)
        {
            BadRequest("Samething wnet wrong!");
        }

        _context.Departments.Update(department);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}

