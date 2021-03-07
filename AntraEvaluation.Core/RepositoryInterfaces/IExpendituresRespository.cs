using BudgetTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.RepositoryInterfaces
{
    public interface IExpendituresRespository
    {
        Task<Expenditure> GetByIdAsync(int Id); // return one record under certain class on corresponding Id
        Task<IEnumerable<Expenditure>> ListAllAsync(); // return all records under certain class
        Task<IEnumerable<Expenditure>> ListAsync(Expression<Func<Expenditure, bool>> filter); //filter: LINQ - where condition
        Task<int> GetCountAsync(Expression<Func<Expenditure, bool>> filter = null); //filter=null means default value of filter is null
        Task<bool> GetExistingAsync(Expression<Func<Expenditure, bool>> filter = null);

        //Creating
        Task<Expenditure> AddAsync(Expenditure entity);

        //Updating
        Task<Expenditure> UpdateAsync(Expenditure entity);

        //Delete
        Task<Expenditure> DeleteAsync(Expenditure entity);
    }
}
