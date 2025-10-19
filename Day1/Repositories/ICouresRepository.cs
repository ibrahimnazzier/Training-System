using Day1.Models;

namespace Day1.Repositories
{
    public interface ICouresRepository : IRepository<Course>
    {
        List<Course> GetCourseById(int deptId);

    }
}
