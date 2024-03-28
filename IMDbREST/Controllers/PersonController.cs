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

        [HttpPost]
        public async Task<ActionResult> AddPerson(PersonDTO personDTO)
        {
            try
            {
                await _personService.AddPerson(personDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
