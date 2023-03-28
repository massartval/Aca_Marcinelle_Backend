using Aca_Marcinelle_Backend.DAL.Entities;
using Aca_Marcinelle_Backend.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aca_Marcinelle_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _repository;
        public CourseController(ICourseRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Course> courses = _repository.GetAll();
            return Ok(courses);
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Course? course = _repository.GetById(id);
            if (course is not null)
                return Ok(course);
            else return BadRequest(id);
        }
        // GET api/<CourseController>/student/5
        [HttpGet("student/{id}")]
        public IActionResult GetByStudentId(int id)
        {
            IEnumerable<Course> courses = _repository.GetByStudentId(id);
            return Ok(courses);
        }

        // POST api/<CourseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
