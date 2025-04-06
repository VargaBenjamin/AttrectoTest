using AttrectoTest.Models.DTOs;
using AttrectoTest.Models.Entities;
using AttrectoTest.Repositories.Interfaces;
using AttrectoTest.Services.Interfaces;
using AutoMapper;

namespace AttrectoTest.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<UserDTO> GetUserAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetUserAsync(id, cancellationToken);

                var userDTO = _mapper.Map<UserDTO>(user);

                return userDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SaveUserAsync(UserSaveDTO user, CancellationToken cancellationToken)
        {
            try
            {
                var userForDB = _mapper.Map<User>(user);

                return await _userRepository.SaveUserAsync(userForDB, cancellationToken);
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
                return await _userRepository.DeleteUserAsync(id, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
