using Application.Dtos;
using Application.Services.Department;
using Microsoft.AspNetCore.Mvc;
using Presentation.DtoMapping;
using Presentation.Models;

namespace Presentation.Controllers;

public class DepartmentController : BaseController
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<IActionResult> Index()
    {
        var departments = await _departmentService.GetAllDepartmentsAsync();

        var viewModel = departments.ToViewModel();

        return View(viewModel);
    }

    public async Task<IActionResult> Detail(Guid id)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }

        var viewModel = department.ToViewModel();
        return View(viewModel);
    }

    //public ActionResult Details(int id)
    //{
    //    return View();
    //}

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateDepartmentViewModel model)
    {
        if(!ModelState.IsValid)
        {
            SetFlashMessage("Please fill in all required fields correctly.", "error");
            return View(model);
        }

        var viewModel = new CreateDepartmentDto
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Description = model.Description
        };

        var result = await _departmentService.CreateDepartmentAsync(viewModel);

        if (result == null)
        {
            SetFlashMessage("An error occurred while creating the department. Please try again.", "error");
            return View(model);
        }

        SetFlashMessage("Department created successfully.", "success");

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Edit(Guid id)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id);

        if (department == null)
        {
            return NotFound();
        }


        return View(department);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(DepartmentDto department)
    {
        if (!ModelState.IsValid)
        {
            return View(department);
        }

        await _departmentService.UpdateDepartmentAsync(department);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id);
        if (department == null) return NotFound();

        return View(department); // This shows a confirmation page
    }

    // POST: DepartmentController/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _departmentService.DeleteDepartmentAsync(id);
        return RedirectToAction(nameof(Index));
    }

}
