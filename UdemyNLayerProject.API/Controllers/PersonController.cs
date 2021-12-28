using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IService<Person> _personService;
        private readonly IMapper _mapper;

        public PersonController(IService<Person> personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var person = await _personService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<PersonDto>>(person));
        }

        [HttpPost]
        public async Task<IActionResult> Save (Person person)
        {
            var addedPerson = await _personService.AddAsync(person);
            return Created(string.Empty,_mapper.Map<PersonDto>(person));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var people =await _personService.GetByIdAsync(id);
            return Ok(_mapper.Map<PersonDto>(people));
        }

        [HttpPut]
        public IActionResult Update(PersonDto personDto)
        {
            var updatedPeople = _personService.Update(_mapper.Map<Person>(personDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var findItem = _personService.GetByIdAsync(id).Result;
            _personService.Remove(findItem);
            return NoContent();
        }
    }
}
