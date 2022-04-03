using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DomainObject.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Models.Student>> GetAllStudents();
        Task<Models.Student> GetStudent(Guid Id);
        Task<bool> CreateStudent(Models.Student student);
        Task<bool> UpdateStudent(Models.Student student);
        Task<bool> DeleteStudent(Guid id);

    }
}
