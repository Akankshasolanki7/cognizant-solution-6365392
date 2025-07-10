using Microsoft.AspNetCore.Mvc;

namespace SwaggerWebApi.Controllers
{
    /// <summary>
    /// ValuesController with enhanced Swagger documentation
    /// Demonstrates ProducesResponseType usage for better API documentation
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // Simple in-memory data storage
        private static List<string> values = new List<string>
        {
            "value1", "value2", "value3"
        };

        /// <summary>
        /// GET: api/values
        /// Returns all values from the collection
        /// </summary>
        /// <returns>List of all values</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<string>))]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            return Ok(values);
        }

        /// <summary>
        /// GET: api/values/5
        /// Returns a specific value by index
        /// </summary>
        /// <param name="id">Index of the value to retrieve</param>
        /// <returns>Single value at specified index</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound($"Value at index {id} not found");
            
            return Ok(values[id]);
        }

        /// <summary>
        /// POST: api/values
        /// Creates a new value in the collection
        /// </summary>
        /// <param name="value">Value to add to the collection</param>
        /// <returns>Success message</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] string value)
        {
            if (string.IsNullOrEmpty(value))
                return BadRequest("Value cannot be null or empty");
            
            values.Add(value);
            return Ok("Value added successfully");
        }

        /// <summary>
        /// PUT: api/values/5
        /// Updates an existing value at specified index
        /// </summary>
        /// <param name="id">Index of the value to update</param>
        /// <param name="value">New value to replace existing one</param>
        /// <returns>Success message</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= values.Count)
                return NotFound($"Value at index {id} not found");
            
            if (string.IsNullOrEmpty(value))
                return BadRequest("Value cannot be null or empty");
            
            values[id] = value;
            return Ok("Value updated successfully");
        }

        /// <summary>
        /// DELETE: api/values/5
        /// Removes a value from the collection
        /// </summary>
        /// <param name="id">Index of the value to delete</param>
        /// <returns>Success message</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound($"Value at index {id} not found");
            
            values.RemoveAt(id);
            return Ok("Value deleted successfully");
        }
    }
}
