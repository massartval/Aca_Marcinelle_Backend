using Aca_Marcinelle_Backend.DAL.Entities;
using Aca_Marcinelle_Backend.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aca_Marcinelle_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IGenericRepository<Person> _repository;
        public PersonController(IGenericRepository<Person> repository)
        {
            _repository = repository;
        }

        #region BASE CRUD
        // GET: api/<PersonController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Person> persons = _repository.GetAll();
            return Ok(persons);
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Person? person = _repository.GetById(id);
            if(person is not null) 
                return Ok(person);
            else return BadRequest(id);
        }

        // POST api/<PersonController>
        [HttpPost]
        public IActionResult Post([FromBody] Person form)
        {
            if(_repository.Create(form))
                return Ok(form);
            return BadRequest(form);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person form)
        {
            if (_repository.Update(form))
                return Ok(form);
            return BadRequest(form);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.Delete(id))
                return Ok(id);
            return BadRequest(id);
        }
        #endregion
    }
}
