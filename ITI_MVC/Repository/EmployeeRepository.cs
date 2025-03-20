using ITI_MVC.Context;
using ITI_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ITI_MVC.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository(ITIContext _context)
        {
            context = _context; //new ITIContext();
        }
        public void Add(Employee obj)
        {
            context.Add(obj);
        }
        public void Update(Employee obj)
        {
            context.Update(obj);
        }
        public void Delete(Employee obj)
        {
            context.Remove(obj);
        }
        public List<Employee> GetAll()
        {
            return context.Employee.ToList();
        }
        public Employee GetById(int id)
        {
            return context.Employee.FirstOrDefault(e => e.Id == id);
        }
        public Employee GetByIdIncludeDepartment(int id)
        {
            return context.Employee.Include("Department").FirstOrDefault(e => e.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
