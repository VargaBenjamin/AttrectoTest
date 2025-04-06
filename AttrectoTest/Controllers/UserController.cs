using AttrectoTest.Models.DTOs;
using AttrectoTest.Models.Entities;
using AttrectoTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AttrectoTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _userService.GetUserAsync(id, cancellationToken));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> SaveUser(UserSaveDTO user, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _userService.SaveUserAsync(user, cancellationToken));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUser(int id, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _userService.DeleteUserAsync(id, cancellationToken));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
