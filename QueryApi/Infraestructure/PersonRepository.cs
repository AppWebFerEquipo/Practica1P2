using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using QueryApi.Domain;
using System.Threading.Tasks;

namespace QueryApi.Repositories
{
    public class PersonRepository
    {
        List<Person> _persons;

        public PersonRepository()
        {
            var fileName = "dummy.data.queries.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _persons = JsonSerializer.Deserialize<IEnumerable<Person>>(json).ToList();
            }
        }

        // retornar todos los valores
        public IEnumerable<Person> GetAll()
        {
            var query = _persons.Select(person => person);
            return query;
        }

        
        // Escribe un método en el cual se retorne únicamente el nombre completo de las personas, el correo y el año de nacimiento.
        public IEnumerable<Object> GetFields()
        {
            var query =_persons.Select(person => new{
                NombreCompleto = $"{person.FirstName} {person.LastName}",
                AnioNacimiento= DateTime.Now.AddYears((person.Age * -1)).Year,
                Correo = person.Email
            });
            return query;
        }
        //Escribe un método que retorne la información de todas las personas cuyo genero sea Femenino.
        public IEnumerable <Person> ObtenerPorGenero(char Gender)
        {
                var query= _persons.Where(person => person.Gender == Gender);
            return query; 
        }
        
        // Escribe un método que retorne la información de todas las personas cuya edad se encuentre entre los 20 y 30 años.
        
        public IEnumerable<Person> ObtenerRango(int minAge, int maxAge)
        {
            var query= _persons.Where(p => p.Age >= minAge && p.Age <= maxAge);
            return query;
        }
        // Escribe un método que retorne la información de los diferentes trabajos que tienen las personas
        public IEnumerable<string> ObtenerTrabajos()
        {
            var query = _persons.Select(person => person.Job).Distinct();
            return query;
        }

        //Escribe un método que retorne la información de las personas cuyo nombre contenga la palabra “ar”
        public IEnumerable<Person> GetContains(string word)
        {
            var query = _persons.Where(p => p.FirstName.Contains(word));
            return query;
        }

        //Escribe un método que retorna la información de las personas cuyas edades sean 25, 35 y 45 años
        public IEnumerable<Person> ObtenerPersona(int Age1,int Age2, int Age3)
        {
            var ages = new List <int>{Age1,Age2,Age3};
            var query = _persons.Where(p => ages.Contains(p.Age));
            return query;
        }

        

        // Escribe un método que retorne la información ordenas por edad para las personas que sean mayores a 40 años
        public IEnumerable<Person> ObtenerOrdenada(int age)
        {
            var query = _persons.Where(person => person.Age > age).OrderBy(person => person.Age);
            return query;
        }
        //Escribe un método que retorne la información ordenada de manera descendente para todas las personas de género masculino y que se encuentren entre los 20 y 30 años de edad
        public IEnumerable<Person> ObtenerOrdenadaDesc(char gender, int minAge, int maxAge)
        {
            var query = _persons.Where(person => person.Gender == gender && person.Age >= minAge && person.Age <= maxAge).OrderByDescending(person => person.Age);
            return query;
        }

        // Escribe un método que retorne la cantidad de personas con género femenino.
        public int ObtenerContador(char gender)
        {
            var query= _persons.Where(p => p.Gender == gender).Count();
            return query;
        }
        //Escribe un método que retorna si existen personas con el apellido “Shemelt”.
        public bool ObtenerExistente(string LastName)
        {
            var query= _persons.Exists(Person=> Person.LastName == LastName);
            return query;
        }

        //Escribe un método que retorne únicamente una persona cuyo trabajo sea “Software Consultant” y tenga 25 años de edad
        public Person TrabajoEdad(string job, int age)
        {
            var query= _persons.Single(Person=>Person.Job == job && Person.Age == age);
            return query;
        }   
        //Escribe un método que retorne la información de las primeras 3 personas cuyo puesto de trabajo sea “Software Consultant”
        public IEnumerable<Person>GetTake(string job, int Take)
        {
            var query= _persons.Where(Person=>Person.Job==job).Take(Take);
            return query;
        }

        //Escribe un método que omita la información de las primeras 3 personas cuyo puesto de trabajo sea “Software Consultant”
        public IEnumerable<Person> GetSkip(int skip,string job)
        {
        var query= _persons.Where(Person=> Person.Job==job).Skip(skip);
        return query;
        }

        //Escribe un método que omita la información de las primeras 3 personas y que retorne la información de las siguientes 3 personas cuyo puesto de trabajo sea “Software Consultant”
        public IEnumerable<Person> GetSkipTake(int skip, int take, string job)
        {
            var query= _persons.Where(Person=>Person.Job == job).Skip(skip).Take(take);
            return query;
        }
    }
}