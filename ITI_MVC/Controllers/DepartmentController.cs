using ITI_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            
            List<Department> dept = context.Department!.ToList();
            return View("Index", dept);
        }

        public IActionResult Add()
        {
            return View("Add");
        }
        public IActionResult SaveDepartment(Department newDeptFromRequest)
        {
            if (newDeptFromRequest.Name != null)
            {
                context.Department!.Add(newDeptFromRequest);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Add", newDeptFromRequest);
        }

    }
}
