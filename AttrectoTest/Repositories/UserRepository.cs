using AttrectoTest.Data.Contexts;
using AttrectoTest.Models.Entities;
using AttrectoTest.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AttrectoTest.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<User> GetUserAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Users.FirstAsync(x => x.Id == id, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SaveUserAsync(User user, CancellationToken cancellationToken)
        {
            try
            {
                if (user.Id > 0)
                {
                    var userDB = await GetUserAsync(user.Id, cancellationToken);
                    if (userDB == null)
                        return false;

                    userDB.Id = user.Id;
                    userDB.Name = user.Name;
                    userDB.Password = user.Password;
                }
                else
                {
                    await _context.AddAsync(user, cancellationToken);
                }

                var affectedRow = await _context.SaveChangesAsync(cancellationToken);

                return affectedRow > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var userDB = await GetUserAsync(id, cancellationToken);

                _context.Users.Remove(userDB);

                var affectedRow = await _context.SaveChangesAsync(cancellationToken);

                return affectedRow > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
