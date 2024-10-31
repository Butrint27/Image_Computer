using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserServices.DTO;
using UserServices.Services;

namespace UserServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm] UserDTO userDto)
        {
            try
            {
                var userId = await _userService.CreateUserAsync(userDto);
                return CreatedAtAction(nameof(GetUser), new { id = userId }, null);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var userDto = await _userService.GetUserAsync(id);
            if (userDto == null || userDto.ImageFile == null)
            {
                return NotFound("User or image not found");
            }

            return File(userDto.ImageFile.OpenReadStream(), "image/jpeg"); // Adjust content type as needed
        }
    }
}
