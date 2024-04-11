// VisitsController.cs
using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitsController : ControllerBase
    {
        private readonly MockDb _mockDb;

        public VisitsController()
        {
            _mockDb = new MockDb();
        }

        [HttpPost]
        public IActionResult AddVisit([FromBody] Visit visit)
        {
            _mockDb.Visits.Add(visit);
            return CreatedAtAction(nameof(GetVisitById), new { visitId = visit.Id }, visit);
        }
        
        [HttpGet("{visitId}")]
        public IActionResult GetVisitById(int visitId)
        {
            var visit = _mockDb.Visits.FirstOrDefault(v => v.Id == visitId);
            if (visit == null)
            {
                return NotFound();
            }
            return Ok(visit);
        }

        [HttpGet("animal/{animalId}")]
        public IActionResult GetVisitsForAnimal(int animalId)
        {
            var visitsForAnimal = _mockDb.Visits.Where(v => v.Animal.Id == animalId).ToList();
            return Ok(visitsForAnimal);
        }
    }
}