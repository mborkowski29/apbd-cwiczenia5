// AnimalsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly MockDb _mockDb;

        public AnimalsController()
        {
            _mockDb = new MockDb();
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            var animals = _mockDb.Animals;
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimalById(int id)
        {
            var animal = _mockDb.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        [HttpPost]
        public IActionResult AddAnimal([FromBody] Animal animal)
        {
            _mockDb.Animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, [FromBody] Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            var existingAnimal = _mockDb.Animals.FirstOrDefault(a => a.Id == id);
            if (existingAnimal == null)
            {
                return NotFound();
            }

            _mockDb.Animals.Remove(existingAnimal);
            _mockDb.Animals.Add(animal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animalToRemove = _mockDb.Animals.FirstOrDefault(a => a.Id == id);
            if (animalToRemove == null)
            {
                return NotFound();
            }

            _mockDb.Animals.Remove(animalToRemove);
            return NoContent();
        }
    }
}
