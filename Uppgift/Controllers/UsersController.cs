using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uppgift.Models;
using Uppgift.Repositories;

namespace Uppgift.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _userRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            var newUser = await _userRepository.Create(user);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser.Id}, newUser);
        }

        [HttpPut]
        public async Task<ActionResult<User>> PutUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userRepository.Update(user);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var deleteUser = await _userRepository.Get(id);
            if(deleteUser != null)
            {
                return NotFound();
            }

            await _userRepository.Delete(deleteUser.Id);
            return NoContent();

        }
    }
}
