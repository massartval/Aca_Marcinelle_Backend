using Aca_Marcinelle_Backend.DAL.Entities;
using Aca_Marcinelle_Backend.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aca_Marcinelle_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        #region BASE CRUD
        // GET: api/<StudentsController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Student> students = _repository.GetAll();
            return Ok(students);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Student? student = _repository.GetById(id);
            if (student is not null)
                return Ok(student);
            else return BadRequest(id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public IActionResult Post([FromBody] Student form)
        {
            if (_repository.Create(form))
                return Ok(form);
            return BadRequest(form);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student form)
        {
            if (_repository.Update(form))
                return Ok(form);
            return BadRequest(form);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.Delete(id))
                return Ok(id);
            return BadRequest(id);
        }
        #endregion

        #region COURSES ACTIONS
        // POST api/<StudentsController>/course
        [HttpPost("course")]
        public IActionResult JoinCourse(int studentId, int courseId)
        {
            bool success = _repository.JoinCourse(studentId, courseId);
            return (success ? Ok(success) : BadRequest(success));
        }

        // DELETE api/<StudentsController>/course/5
        [HttpDelete("{studentId}/course/{courseId}")]
        public IActionResult LeaveCourse(int studentId, int courseId)
        {
            bool success = _repository.LeaveCourse(studentId, courseId);
            return (success ? Ok(success) : BadRequest(success));
        }

        // PUT api/<StudentsController>/course/5
        [HttpPut("{studentId}/course/{courseId}")]
        public IActionResult ChangeLevel(int studentId, int courseId, int levelId)
        {
            bool success = _repository.ChangeLevel(studentId, courseId, levelId);
            return (success ? Ok(success) : BadRequest(success));
        }
        #endregion

        #region GROUPS ACTIONS
        // POST api/<StudentsController>/group
        [HttpPost("group")]
        public IActionResult JoinGroup(int studentId, int groupId)
        {
            bool success = _repository.JoinGroup(studentId, groupId);
            return (success ? Ok(success) : BadRequest(success));
        }

        // DELETE api/<StudentsController>/group/5
        [HttpDelete("{studentId}/group/{groupId}")]
        public IActionResult LeaveGroup(int studentId, int groupId)
        {
            bool success = _repository.LeaveGroup(studentId, groupId);
            return (success ? Ok(success) : BadRequest(success));
        }
        #endregion
    }
}
