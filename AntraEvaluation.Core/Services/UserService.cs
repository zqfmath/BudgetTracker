using BudgetTracker.Core.Entities;
using BudgetTracker.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetTracker.Core.RepositoryInterfaces;
using BudgetTracker.Core.Models.Response;
using AutoMapper;
using BudgetTracker.Core.Models.Request;

namespace BudgetTracker.Core.Services
{
    public class UserService: IUserService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUsersRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddUser(UserAddModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
             await _userRepository.AddAsync(user);
            return true;
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {

            List<UserResponseModel> result = new List<UserResponseModel>();
            var users = await _userRepository.ListAllAsync();
            foreach (var user in users)
            {
                result.Add(_mapper.Map<UserResponseModel>(user));
            }
            return result;
        }

    

        public async Task<UserResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserResponseModel>(user);
        }

        public async Task<bool> UpdateUser(UserUpdateModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            await _userRepository.UpdateAsync(user);
            return true;
        }
        public async Task<bool> ExistUser(int id)
        {
            return await _userRepository.GetExistingAsync(t => t.Id == id);
        }
        public async Task<bool> ExistUser(string email)
        {
            return await _userRepository.GetExistingAsync(t => t.Email == email);
        }

        public async Task<bool> DeleteUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(user);
            return true;
        }
    }
}
