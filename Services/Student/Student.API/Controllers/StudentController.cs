using Microsoft.AspNetCore.Mvc;
using Student.DomainObject.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly StudentRepository _studentRepository;

        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IEnumerable<DomainObject.Models.Student>> Get()
        {
            return await _studentRepository.GetAllStudents();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<DomainObject.Models.Student> Get(Guid id)
        {
            return await _studentRepository.GetStudent(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<bool> Post([FromBody] DomainObject.Models.Student value)
        {
           return await _studentRepository.CreateStudent(value);
        }

        //PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put([FromBody] DomainObject.Models.Student value)
        {
            return await _studentRepository.UpdateStudent(value);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _studentRepository.DeleteStudent(id);
        }
    }
}
