using ITI_MVC.Models;

namespace ITI_MVC.Repository
{
    public interface IDepartmentRepository
    {
        public void Add(Department obj);
        public void Update(Department obj);
        public void Delete(Department obj);
        public List<Department> GetAll();
        public Department GetById(int id);
        public void Save();
    }
}
