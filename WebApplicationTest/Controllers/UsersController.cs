using Microsoft.AspNetCore.Mvc;
using WebApplicationTest.Data.Interfaces;
using WebApplicationTest.Models;

namespace WebApplicationTest.Controllers
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

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var users = await _userRepository.CreateUser(user);
            return Ok(users);
        }

        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            var users = await _userRepository.EditUser(user);
            return Ok(users);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var users = await _userRepository.DeleteUser(id);
            return Ok(users);
        }

        [HttpGet("Image")]
        public async Task<IActionResult> GetImage()
        {
            var image = await _userRepository.GetImage();
            return Ok(image);
        }
    }
}
