using Day1.Models;
using Microsoft.EntityFrameworkCore;

namespace Day1.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        Context Context;
        public DepartmentRepository(Context _context)
        {
            Context = _context;
        }
        public void Add(Department entity)
        {
         Context.Add(entity);   
        }

        public void Delete(int id)
        {
            Department? department = GetByID(id);
            Context.Department.Remove(department);
        }

        public List<Department> GetAll(string? includes = null)
        {
            var query = Context.Department.AsQueryable();

            if (!string.IsNullOrEmpty(includes))
            {
                query = query.Include(includes);
            }

            return query.ToList();
        }

        public Department? GetByID(int id)
        {
            return Context.Department.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            Context?.SaveChanges();
        }

        public void Update(Department entity)
        {
            Department? department = GetByID((int)entity.Id);
            department.Name = entity.Name;
            department.Manager = entity.Manager;
        }
    }
}
