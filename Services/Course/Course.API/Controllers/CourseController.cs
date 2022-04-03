using Course.DomainObject.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Course.API.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IEnumerable<DomainObject.Models.Course>> Get()
        {
            return await _courseRepository.GetAllCourses();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<DomainObject.Models.Course> Get(Guid id)
        {
            return await _courseRepository.GetCourse(id);
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<bool> Post([FromBody] DomainObject.Models.Course value)
        {
            return await _courseRepository.UpdateCourse(value);
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put([FromBody] DomainObject.Models.Course value)
        {
            return await _courseRepository.UpdateCourse(value);
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _courseRepository.DeleteCourse(id);
        }
    }
}
