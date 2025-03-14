﻿using ITI_MVC.Models;
using ITI_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Details(int id)
        {
            string msg = "Hello From Action";
            int temp = 50;
            List<String> Branches = new List<String>();
            Branches.Add("Cairo");
            Branches.Add("Assuit");
            Branches.Add("Menofia");
            Branches.Add("Giza");

            Employee empModel = context.Employee.FirstOrDefault(p => p.Id == id);
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

            Employee empModel = context.Employee.Include("Department").FirstOrDefault(p => p.Id == id);
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
            var employess = context.Employee.ToList();
            return View("Index", employess);
        }
        //public IActionResult Edit(int id)
        //{
        //    Employee employeeModel = context.Employee.FirstOrDefault(E => E.Id == id);
        //    return View("Edit", employeeModel);
        //}

        public IActionResult Edit(int id)
        {
            Employee employeeModel = context.Employee.FirstOrDefault(E => E.Id == id);
            EmpDeptListViewModel EmpDeptListViewMOdel = new EmpDeptListViewModel();
            List<Department> DepartmentList = context.Department.ToList();
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
            Employee EmployeeFromDB = context.Employee.FirstOrDefault(e => e.Id == id);
            if (EmpDeptFromREquest.Name != null)
            {
                //if (EmployeeFromDB == null)
                //{
                //    return NotFound("Employee not found");
                //}
                List<Department> DepartmentList = context.Department.ToList();
                EmployeeFromDB.Name = EmpDeptFromREquest.Name;
                EmployeeFromDB.Salary = EmpDeptFromREquest.Salary;
                EmployeeFromDB.Address = EmpDeptFromREquest.Address;
                EmployeeFromDB.ImageURL = EmpDeptFromREquest.ImageURL;
                EmployeeFromDB.JobTitle = EmpDeptFromREquest.JobTitle;
                EmployeeFromDB.DepartmentID = EmpDeptFromREquest.DepartmentID;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", EmpDeptFromREquest);

        }

    }
}

