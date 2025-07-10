using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    /// <summary>
    /// ValuesController demonstrates basic Web API with Read/Write permissions
    /// Shows all HTTP action verbs corresponding to CRUD operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // Simple in-memory data storage for demonstration
        private static List<string> values = new List<string>
        {
            "value1", "value2", "value3"
        };

        /// <summary>
        /// GET: api/values
        /// Read operation - Returns all values
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(values); // Returns 200 OK with data
        }

        /// <summary>
        /// GET: api/values/5
        /// Read operation - Returns specific value by index
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound(); // Returns 404 Not Found
            
            return Ok(values[id]); // Returns 200 OK with specific value
        }

        /// <summary>
        /// POST: api/values
        /// Write operation - Creates new value
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            if (string.IsNullOrEmpty(value))
                return BadRequest(); // Returns 400 Bad Request
            
            values.Add(value);
            return Ok("Value added successfully"); // Returns 200 OK
        }

        /// <summary>
        /// PUT: api/values/5
        /// Write operation - Updates existing value
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= values.Count)
                return NotFound(); // Returns 404 Not Found
            
            if (string.IsNullOrEmpty(value))
                return BadRequest(); // Returns 400 Bad Request
            
            values[id] = value;
            return Ok("Value updated successfully"); // Returns 200 OK
        }

        /// <summary>
        /// DELETE: api/values/5
        /// Write operation - Deletes value
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound(); // Returns 404 Not Found
            
            values.RemoveAt(id);
            return Ok("Value deleted successfully"); // Returns 200 OK
        }
    }
}
