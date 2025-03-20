using ITI_MVC.Models;

namespace ITI_MVC.Repository
{
    public interface IEmployeeRepository
    {
        public void Add(Employee obj);
        public void Update(Employee obj);
        public void Delete(Employee obj);
        public List<Employee> GetAll();
        public Employee GetById(int id);
        public Employee GetByIdIncludeDepartment(int id);
        public void Save();

    }
}
