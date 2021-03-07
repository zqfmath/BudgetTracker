using BudgetTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.RepositoryInterfaces
{
    public interface IIncomesRepository
    {
        Task<Income> GetByIdAsync(int Id); // return one record under certain class on corresponding Id
        Task<IEnumerable<Income>> ListAllAsync(); // return all records under certain class
        Task<IEnumerable<Income>> ListAsync(Expression<Func<Income, bool>> filter); //filter: LINQ - where condition
        Task<int> GetCountAsync(Expression<Func<Income, bool>> filter = null); //filter=null means default value of filter is null
        Task<bool> GetExistingAsync(Expression<Func<Income, bool>> filter = null);

        Task<Income> AddAsync(Income entity);

        Task<Income> UpdateAsync(Income entity);

        Task<Income> DeleteAsync(Income entity);
    }
}
