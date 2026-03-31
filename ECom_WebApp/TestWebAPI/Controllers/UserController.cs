using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TestWebAPI.Filters;

namespace TestWebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    //[AuthorizationFilter]
    [ResultFilter]
    public class UserController : ControllerBase
    {
        // In-memory list to simulate a data store
        private static List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com" },
            new User { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com" },
            new User { Id = 3, FirstName = "Michal", LastName = "Annapa", Email = "Mic@example.com" },

        };

        // GET: api/users

        [HttpGet]
        public IActionResult GetUsers() => Ok(_users);

        // GET: api/users/1
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);  
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (updatedUser == null || updatedUser.Id != id)
                return BadRequest();

            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;

            return NoContent();
        }

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();

            _users.Remove(user);
            return NoContent();
        }
    }
}
