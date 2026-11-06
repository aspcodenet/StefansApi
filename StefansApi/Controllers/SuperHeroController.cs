using Microsoft.AspNetCore.Mvc;
using StefansApi.Models;

namespace StefansApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private static readonly List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "Spiderman",
                FirstName = "Peter",
                SurName = "Parker",
                City = "New York"
            },
            new SuperHero
            {
                Id = 2,
                Name = "Ironman",
                FirstName = "Tony",
                SurName = "Stark",
                City = "New York"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            return Ok(heroes);
        }
        [HttpPost]
        public async  Task<ActionResult<SuperHero>> PostHero(SuperHero hero)
        {
            heroes.Add(hero);
            return CreatedAtAction(nameof(Get), new { id = hero.Id },   hero);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heroes.FirstOrDefault(h => h.Id == id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }
    }
}