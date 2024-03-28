using IMDbLib.DTOs;
using IMDbLib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDbREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        // GET: api/Person?searchString={searchString}
        [HttpGet]
        public async Task<ActionResult<List<PersonDTO>>> SearchPersons(string searchString)
        {
            var persons = await _personService.GetPersonListByName(searchString);
            return Ok(persons);
        }
    }
}
