using ITI_MVC.Context;
using ITI_MVC.Models;
using ITI_MVC.Repository;
using ITI_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        //ITIContext context = new ITIContext();
        IDepartmentRepository departmentRepository;
        IEmployeeRepository employeeRepository;
        public EmployeeController(IDepartmentRepository _departmentRepository, 
            IEmployeeRepository _employeeRepository)
        {
            departmentRepository = _departmentRepository;
            employeeRepository = _employeeRepository;
        }
        public IActionResult Details(int id)
        {
            string msg = "Hello From Action";
            int temp = 50;
            List<String> Branches = new List<String>();
            Branches.Add("Cairo");
            Branches.Add("Assuit");
            Branches.Add("Menofia");
            Branches.Add("Giza");

            //Employee empModel = context.Employee.FirstOrDefault(p => p.Id == id);
            Employee empModel = employeeRepository.GetById(id);
            ViewData["msg"] = msg;
            ViewData["temp"] = temp;
            ViewData["Branches"] = Branches;


            return View("Details", empModel);
        }
        public IActionResult DetailsVM(int id)
        {
            List<String> branches = new List<String>();
            branches.Add("Cairo");
            branches.Add("Assuit");
            branches.Add("Menofia");
            branches.Add("Giza");
            EmpDeptColorTempMsgBrnchViewModel EmpDeptVM =
                new EmpDeptColorTempMsgBrnchViewModel();

            Employee empModel = employeeRepository.GetByIdIncludeDepartment(id);
            EmpDeptVM.EmpName = empModel.Name;
            EmpDeptVM.DeptName = empModel.Department.Name;

            EmpDeptVM.Branches = branches;
            EmpDeptVM.Temp = 60;
            EmpDeptVM.Msg = "Hello From View Models";
            EmpDeptVM.Color = "Red";
            return View("DetailsVM", EmpDeptVM);
        }
        public IActionResult Index()
        {
            //var employess = context.Employee.ToList();
            var employess = employeeRepository.GetAll();
            return View("Index", employess);
        }
        //public IActionResult Edit(int id)
        //{
        //    Employee employeeModel = context.Employee.FirstOrDefault(E => E.Id == id);
        //    return View("Edit", employeeModel);
        //}

        public IActionResult Edit(int id)
        {
            //Employee employeeModel = context.Employee.FirstOrDefault(E => E.Id == id);
            Employee employeeModel = employeeRepository.GetById(id);
            EmpDeptListViewModel EmpDeptListViewMOdel = new EmpDeptListViewModel();
            //List<Department> DepartmentList = context.Department.ToList();
            List<Department> DepartmentList = departmentRepository.GetAll();
            EmpDeptListViewMOdel.Id = employeeModel.Id;
            EmpDeptListViewMOdel.Name = employeeModel.Name;
            EmpDeptListViewMOdel.Salary = employeeModel.Salary;
            EmpDeptListViewMOdel.Address = employeeModel.Address;
            EmpDeptListViewMOdel.ImageURL = employeeModel.ImageURL;
            EmpDeptListViewMOdel.JobTitle = employeeModel.JobTitle;
            EmpDeptListViewMOdel.DepartmentID = employeeModel.DepartmentID;
            EmpDeptListViewMOdel.DeptList = DepartmentList;
            return View("Edit", EmpDeptListViewMOdel);
        }

        public IActionResult SaveEdit(EmpDeptListViewModel EmpDeptFromREquest, int id)
        {
            //Employee EmployeeFromDB = context.Employee.FirstOrDefault(e => e.Id == id);
            Employee EmployeeFromDB = employeeRepository.GetById(id);
            if (EmpDeptFromREquest.Name != null)
            {
                //if (EmployeeFromDB == null)
                //{
                //    return NotFound("Employee not found");
                //}
                //List<Department> DepartmentList = context.Department.ToList();
                List<Department> DepartmentList = departmentRepository.GetAll();
                EmployeeFromDB.Name = EmpDeptFromREquest.Name;
                EmployeeFromDB.Salary = EmpDeptFromREquest.Salary;
                EmployeeFromDB.Address = EmpDeptFromREquest.Address;
                EmployeeFromDB.ImageURL = EmpDeptFromREquest.ImageURL;
                EmployeeFromDB.JobTitle = EmpDeptFromREquest.JobTitle;
                EmployeeFromDB.DepartmentID = EmpDeptFromREquest.DepartmentID;
                //context.SaveChanges();
                employeeRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Edit", EmpDeptFromREquest);

        }

        [HttpGet]
        public IActionResult Add()
        {
            //ViewData["DeptList"] = context.Department.ToList();
            ViewData["DeptList"] = departmentRepository.GetAll();
            return View("Add");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAdd(Employee employee)
        {
            //Employee employee = new Employee();
            
            if (ModelState.IsValid == true)
            {
                if (employee.DepartmentID != 0)
                {
                    //context.Employee.Add(employee);
                    //context.SaveChanges();
                    employeeRepository.Add(employee);
                    employeeRepository.Save();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("DepartmentID", "Select Department");
            }
            //ViewData["DeptList"] = context.Department.ToList();
            ViewData["DeptList"] = departmentRepository.GetAll();
            return View("Add", employee);
        }
        // Remote Attribute Using Ajax Call
        public IActionResult CheckName(string name)
        {
            if (name.Contains("ITI"))
            {
                return Json(true);
            }
            return Json(false);

        }
        

    }
}

