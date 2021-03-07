using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> AddUser(UserAddModel user);
        Task<bool> UpdateUser(UserUpdateModel user);
        Task<UserResponseModel> GetUserById(int id);
        Task<IEnumerable<UserResponseModel>> GetAllUsers();
        Task<bool> ExistUser(int id);
        Task<bool> ExistUser(string email);
        Task<bool> DeleteUserById(int id);

    }
}
