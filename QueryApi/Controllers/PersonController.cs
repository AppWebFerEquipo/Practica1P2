using System.Collections;
using Microsoft.AspNetCore.Mvc;
using QueryApi.Repositories;
using QueryApi.Domain;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var repository = new PersonRepository();
            var persons = repository.GetAll();
            return Ok(persons);
        } 
        
        [HttpGet]
        [Route("GetFields")]
        public IActionResult GetFields()
        {
            var repository = new PersonRepository();
            var persons = repository.GetFields();
            return Ok(persons);
        }

        [HttpGet]
        [Route("ObtenerPorGenero")]
        public IActionResult ObtenerPorGenero(char gender)
        {
            var repository = new PersonRepository();
            var persons = repository.ObtenerPorGenero(gender);
            return Ok(persons);
        }

        [HttpGet]
        [Route("ObtenerRango")]
        public IActionResult ObtenerRango(int min_Age, int max_Age)
        {
            var repository = new PersonRepository();
            var persons = repository.ObtenerRango(min_Age,max_Age);
            return Ok(persons);
        }  

        [HttpGet]
        [Route("ObtenerTrabajos")]
        public IActionResult ObtenerTrabajos()
        {
            var repository = new PersonRepository();
            var persons = repository.ObtenerTrabajos();
            return Ok(persons);
        }    

        [HttpGet]
        [Route("GetContains")]
        public IActionResult GetContains(string word)
        {
            var repository = new PersonRepository();
            var persons = repository.GetContains(word);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("ObtenerPersona")]
        public IActionResult ObtenerPersona(int Age1,int Age2,int Age3)
        {
            var repository = new PersonRepository();
            var persons = repository.ObtenerPersona(Age1,Age2,Age3);
            return Ok(persons);
        }
        
        [HttpGet]
        [Route("ObtenerOrdenada")]
        public IActionResult ObtenerOrdenada(int age)
        {
            var repository = new PersonRepository();
            var persons = repository.ObtenerOrdenada(age);
            return Ok(persons);
        }

        [HttpGet]
        [Route("ObtenerOrdenadaDesc")]
        public IActionResult ObtenerOrdenadaDesc(char gender, int minAge,int maxAge)
        {
            var repository = new PersonRepository();
            var persons = repository.GetOrderedDesc(gender,minAge,maxAge);
            return Ok(persons);
        }

        [HttpGet]
        [Route("ObtenerContador")]
        public IActionResult ObtenerContador(char gender)
        {
            var repository = new PersonRepository();
            var persons = repository.ObtenerContador(gender);
            return Ok(persons);
        }

        [HttpGet]
        [Route("ObtenerExistente")]
        public IActionResult ObtenerExistente(string LastName)
        {
            var repository = new PersonRepository();
            var persons = repository.ObtenerExistente(LastName);
            return Ok(persons);
        }

        [HttpGet]
        [Route("TrabajoEdad")]
        public IActionResult TrabajoEdad(string Job, int age)
        {
            var repository = new PersonRepository();
            var persons = repository.TrabajoEdad(Job,age);
            return Ok(persons);
        }

        [HttpGet]
        [Route("GetTake")]
        public IActionResult GetTake(string job, int Take)
        {
            var repository = new PersonRepository();
            var persons = repository.GetTake(job,Take);
            return Ok(persons);
        }

        [HttpGet]
        [Route("GetSkip")]
        public IActionResult GetSkip(int skip,string job)
        {
            var repository = new PersonRepository();
            var persons = repository.GetSkip(skip,job);
            return Ok(persons);
        }

        [HttpGet]
        [Route("GetSkipTake")]
        public IActionResult GetSkipTake(int skip,int take, string job)
        {
            var repository = new PersonRepository();
            var persons = repository.GetSkipTake(skip,take,job);
            return Ok(persons);
        }

    }
}