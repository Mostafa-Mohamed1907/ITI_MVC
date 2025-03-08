using ITI_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            ITIContext context = new ITIContext();
            List<Department> dept = context.Department.ToList();
            return View("Index", dept);
        }
    }
}
