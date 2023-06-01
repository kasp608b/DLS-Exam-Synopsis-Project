using Microsoft.AspNetCore.Mvc;
using WeebAPI;
using WeebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthorsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeebController : ControllerBase
    {
        private readonly WeebDatabaseService _weebService;

        public WeebController(WeebDatabaseService weebService)
        {
            _weebService = weebService;
        }

        // GET: api/<WeebController>
        [HttpGet]
        public async Task<List<Weeb>> Get() =>
        await _weebService.GetAsync();

        // GET api/<WeebController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weeb>> Get(string id)
        {
            var weeb = await _weebService.GetAsync(id);

            if (weeb is null)
            {
                return NotFound();
            }

            return weeb;
        }

        // POST api/<WeebController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Weeb newWeeb)
        {
            var weeb = await _weebService.CreateAsync(newWeeb);

            return CreatedAtAction(nameof(Get), new { id = weeb._id }, weeb);
        }

        // PUT api/<WeebController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Weeb updatedWeeb)
        {
            var weeb = await _weebService.GetAsync(id);

            if (weeb is null)
            {
                return NotFound();
            }

            updatedWeeb._id = weeb._id;

            await _weebService.UpdateAsync(id, updatedWeeb);

            return NoContent();
        }

        // DELETE api/<WeebController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var weeb = await _weebService.GetAsync(id);

            if (weeb is null)
            {
                return NotFound();
            }

            await _weebService.RemoveAsync(id);

            return NoContent();
        }
    }
}
