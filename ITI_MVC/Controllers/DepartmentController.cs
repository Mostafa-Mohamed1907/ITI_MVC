using ITI_MVC.Context;
using ITI_MVC.Models;
using ITI_MVC.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DepartmentController : Controller
    {
        //ITIContext context = new ITIContext();
        IDepartmentRepository departmentRepository;
        IEmployeeRepository employeeRepository;
        public DepartmentController(IDepartmentRepository _departmentRepository
            , IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
            departmentRepository = _departmentRepository;
        }
        [Authorize]
        public IActionResult Index()
        {

            //List<Department> dept = context.Department!.ToList();
            List<Department> dept = departmentRepository.GetAll();
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
                //context.Department!.Add(newDeptFromRequest);
                //context.SaveChanges();
                departmentRepository.Add(newDeptFromRequest);
                departmentRepository.Save();

                return RedirectToAction("Index");
            }
            return View("Add", newDeptFromRequest);
        }

    }
}
