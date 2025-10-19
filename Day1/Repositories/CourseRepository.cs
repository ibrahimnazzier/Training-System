using Day1.Models;
using Microsoft.EntityFrameworkCore;

namespace Day1.Repositories
{
    public class CourseRepository : ICouresRepository
    {
        Context context;

        public CourseRepository(Context context)
        {
            this.context = context;
        }

        public void Add(Course entity)
        {
            context.Course.Add(entity);
        }

        public void Delete(int id)
        {
            Course? course = GetByID(id);

            context.Course.Remove(course);
        }

        public List<Course> GetAll(string? includes = null)
        {
            return context.Course.Include(includes).ToList();
        }

        public Course? GetByID(int id)
        {
            return context.Course.FirstOrDefault(c=> c.Id == id);
        }

        public List<Course> GetCourseById(int deptId)
        {
            return context.Course.Where(c => c.DepartmentID == deptId).ToList();
            //throw new NotImplementedException(deptId);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Course entity)
        {
            Course? course = GetByID(entity.Id);
            course.Name = entity.Name;
            course.minDegree = entity.minDegree;
            course.degree = entity.degree;
            course.Hours = entity.Hours;
            course.DepartmentID = entity.DepartmentID;
        }
    }
}
