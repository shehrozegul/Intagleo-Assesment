using Microsoft.EntityFrameworkCore;
using Student.DomainObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DomainObject.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public readonly StudentContext _studentContext;

        public StudentRepository(StudentContext studentContext)
        {
            _studentContext = studentContext ?? throw new ArgumentNullException(nameof(studentContext));
        }

        public async Task<bool> CreateStudent(Models.Student student)
        {
            try
            {
                var stu = new Models.Student();
                stu = student;
                _studentContext.Students?.AddAsync(stu);
                var isSaved = await _studentContext.SaveChangesAsync();
                return isSaved > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Models.Student> GetStudent(Guid Id)
        {
            try
            {
                var result = await _studentContext.Students?.Where(x => x.ID == Id).SingleOrDefaultAsync()!;
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<bool> DeleteStudent(Guid Id)
        {
            try
            {
                var result = _studentContext.Students?.Where(x => x.ID == Id).SingleOrDefault() ;
                _studentContext.Students?.Remove(result!);
                var isSaved = await _studentContext.SaveChangesAsync();
                return isSaved > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Models.Student>> GetAllStudents()
        {
            try
            {
                return await _studentContext.Students?.ToListAsync()!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateStudent(Models.Student student)
        {
            try
            {
                var result= await _studentContext.Students?.Where(x=>x.ID== student.ID).SingleOrDefaultAsync()!;
                result = student;
                _studentContext.Update(result);
                var isSaved = await _studentContext.SaveChangesAsync();
                return isSaved > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
