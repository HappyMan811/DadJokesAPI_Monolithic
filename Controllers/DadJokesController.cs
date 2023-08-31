using DadJokesAPI_Monolithic.Models;
using Microsoft.AspNetCore.Mvc;

namespace DadJokesAPI_Monolithic.Controllers
{
	[Route("api/[controller]")]	
	public class DadJokesController : Controller
	{
		private static List<DadJoke> _jokes = new List<DadJoke>();

		// GET: api/DadJokess
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_jokes);
		}

		// GET: api/DadJokes/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var joke = _jokes.FirstOrDefault(j => j.Id == id);

			if (joke == null)
			{
				return NotFound();
			}

			return Ok(joke);
		}

		// POST: api/DadJokes
		[HttpPost]
		public IActionResult Post([FromBody] DadJoke joke)
		{
			_jokes.Add(joke);

			return CreatedAtAction(nameof(Get), new { id = joke.Id }, joke);
		}

		// PUT: api/DadJokes/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] DadJoke joke)
		{
			var existingJoke = _jokes.FirstOrDefault(j => j.Id == id);

			if (existingJoke == null)
			{
				return NotFound();
			}

			existingJoke.Joke = joke.Joke;

			existingJoke.Punchline = joke.Punchline;

			return NoContent();
		}

		// DELETE: api/DadJokes/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var joke = _jokes.FirstOrDefault(j => j.Id == id);

			if (joke == null)
			{
				return NotFound();
			}

			_jokes.Remove(joke);

			return NoContent();
		}
	}
}
