using BudgetTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.RepositoryInterfaces
{
    public interface IUsersRepository
    {
        Task<User> GetByIdAsync(int Id); // return one record under certain class on corresponding Id
        Task<IEnumerable<User>> ListAllAsync(); // return all records under certain class
        Task<IEnumerable<User>> ListAsync(Expression<Func<User, bool>> filter); //filter: LINQ - where condition
        Task<int> GetCountAsync(Expression<Func<User, bool>> filter = null); //filter=null means default value of filter is null
        Task<bool> GetExistingAsync(Expression<Func<User, bool>> filter = null);

        //Creating
        Task<User> AddAsync(User entity);

        //Updating
        Task<User> UpdateAsync(User entity);

        //Delete
        Task<User> DeleteAsync(User entity);
    }
}
