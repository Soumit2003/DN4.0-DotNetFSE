using Microsoft.AspNetCore.Mvc;

namespace Experiment1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        // Simulated in-memory data
        private static readonly List<string> values = new() { "value1", "value2" };

        // GET /values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(values);
        }

        // GET /values/{id}
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound("Invalid ID");
            return Ok(values[id]);
        }

        // POST /values
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            values.Add(value);
            return CreatedAtAction(nameof(Get), new { id = values.Count - 1 }, value);
        }

        // PUT /values/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= values.Count)
                return NotFound("Invalid ID");
            values[id] = value;
            return NoContent();
        }

        // DELETE /values/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound("Invalid ID");
            values.RemoveAt(id);
            return NoContent();
        }
    }
}
