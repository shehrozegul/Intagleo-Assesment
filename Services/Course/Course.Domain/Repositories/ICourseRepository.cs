using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.DomainObject.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Models.Course>> GetAllCourses();
        Task<Models.Course> GetCourse(Guid Id);
        Task<bool> CreateCourse(Models.Course course);
        Task<bool> UpdateCourse(Models.Course course);
        Task<bool> DeleteCourse(Guid id);
    }
}
