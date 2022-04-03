using Course.DomainObject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.DomainObject.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public readonly CourseContext _courseContext;

        public CourseRepository(CourseContext courseContext)
        {
            _courseContext = courseContext ?? throw new ArgumentNullException(nameof(courseContext));
        }
        public async Task<bool> CreateCourse(Models.Course course)
        {
            try
            {
                var stu = new Models.Course();
                stu = course;
                _courseContext.Courses?.AddAsync(stu);
                var isSaved = await _courseContext.SaveChangesAsync();
                return isSaved > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            try
            {
                var result = _courseContext.Courses?.Where(x => x.CourseID == id).SingleOrDefault();
                _courseContext.Courses?.Remove(result!);
                var isSaved = await _courseContext.SaveChangesAsync();
                return isSaved > 0;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<IEnumerable<Models.Course>> GetAllCourses()
        {
            try
            {
                return await _courseContext.Courses?.ToListAsync()!;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Models.Course> GetCourse(Guid Id)
        {
            try
            {
                var result = await _courseContext.Courses?.Where(x => x.CourseID == Id).SingleOrDefaultAsync()!;
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateCourse(Models.Course course)
        {
            try
            {
                var result = await _courseContext.Courses?.Where(x => x.CourseID == course.CourseID).SingleOrDefaultAsync()!;
                result = course;
                _courseContext.Update(result);
                var isSaved = await _courseContext.SaveChangesAsync();
                return isSaved > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
