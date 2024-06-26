﻿using IMDbLib.DTOs;
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

        [HttpGet("{nconst}")]
        public async Task<IActionResult> GetAllPersonInfo(string nconst)
        {
            try
            {
                var personInfo = await _personService.GetAllPersonInfoByNconst(nconst);
                return Ok(personInfo); // Return a Ok status code with the person info
            }
            catch (Exception ex)
            {
                // Log the exception...
                return NotFound(); // Return a NotFound status code if the person was not found
            }
        }

        [HttpDelete("{nconst}")]
        public async Task<IActionResult> DeletePerson(string nconst)
        {
            try
            {
                await _personService.DeletePerson(nconst);
                return NoContent(); // Return a NoContent status code to indicate that the resource was deleted successfully
            }
            catch (Exception ex)
            {
                // Log the exception...
                return BadRequest(); // Return a BadRequest status code if something went wrong
            }
        }
    }
}
