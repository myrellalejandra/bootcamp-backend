using Bootcamp.Model;
using Bootcamp.Queries.Person;
using Bootcamp.Repository;
using Bootcamp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonQueries _personQueries;
        public PersonController(IPersonRepository personRepository, IPersonQueries iPersonQueries)
        {
            _personRepository = personRepository;
            _personQueries = iPersonQueries;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] Person person)
        {
            var result = await _personRepository.Create(person);
            return Ok(result);
        }

        [HttpGet]
        [Route("Read")]
        public async Task<ActionResult> Read()
        {
            var result = await _personQueries.Read();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _personQueries.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] Person person)
        {
            var result = await _personRepository.Update(person);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int  id)
        {
            var result = await _personRepository.Delete(id);
            return Ok(result);
        }
    }
}
