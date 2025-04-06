using AttrectoTest.Models.Entities;

namespace AttrectoTest.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int id, CancellationToken cancellationToken);
        Task<bool> SaveUserAsync(User user, CancellationToken cancellationToken);
        Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken);
    }
}
