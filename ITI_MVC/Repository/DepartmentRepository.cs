using ITI_MVC.Context;
using ITI_MVC.Models;

namespace ITI_MVC.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ITIContext context;
        public DepartmentRepository(ITIContext _context)
        {
            context = _context; //new ITIContext();
        }
        public void Add(Department obj)
        {
            context.Add(obj);
        }
        public void Update(Department obj)
        {
            context.Update(obj);
        }
        public void Delete(Department obj)
        {
            context.Remove(obj);
        }
        public List<Department> GetAll()
        {
            return context.Department.ToList();
        }
        public Department GetById(int id)
        {
            return context.Department.FirstOrDefault(e => e.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
