using AttrectoTest.Models.DTOs;
using AttrectoTest.Models.Entities;

namespace AttrectoTest.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserAsync(int id, CancellationToken cancellationToken);
        Task<bool> SaveUserAsync(UserSaveDTO user, CancellationToken cancellationToken);
        Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken);
    }
}
