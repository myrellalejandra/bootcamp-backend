using Bootcamp.Model;
using Bootcamp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private  readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
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
            var result = await _personRepository.Read();
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] Person person)
        {
            var result = await _personRepository.Update(person);
            return Ok(result);
        }

        [HttpGet]
        [Route("Delete")]
        public async Task<ActionResult> Delete([FromBody] Person person)
        {
            var result = await _personRepository.Delete(person);
            return Ok(result);
        }
    }
}
