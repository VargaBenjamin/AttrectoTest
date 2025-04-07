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

        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUser(int id, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(id, 1);

                return Ok(await _userService.GetUserAsync(id, cancellationToken));
            }
            catch (ArgumentOutOfRangeException)
            {
                return Conflict($"Out of range");
            }
            catch (Exception ex)
            {
                return NotFound($"Unknown error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> SaveUser(UserSaveDTO user, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNullOrEmpty(user.Name);
                ArgumentNullException.ThrowIfNullOrEmpty(user.Password);

                return Ok(await _userService.SaveUserAsync(user, cancellationToken));
            }
            catch (ArgumentException ex)
            {
                return Conflict($"The value cannot be an empty");
            }
            catch (Exception ex)
            {
                return Conflict($"Unknown error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUser(int id, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(id, 1);

                return Ok(await _userService.DeleteUserAsync(id, cancellationToken));
            }
            catch (ArgumentOutOfRangeException)
            {
                return Conflict($"Out of range");
            }
            catch (Exception ex)
            {
                return NotFound($"Unknown error: {ex.Message}");
            }
        }
    }
}
