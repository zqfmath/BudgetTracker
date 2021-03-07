using BudgetTracker.Core.Entities;
using BudgetTracker.Core.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Repositories
{
    public class ExpendituresRespository : IExpendituresRespository
    {
        protected readonly BudgetTrackerDbContext _dbContext; // protected: current class and its subclasses
        public ExpendituresRespository(BudgetTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<Expenditure> AddAsync(Expenditure entity) // make all the methods virtural: we can override those methods in other repositories(e.g.: MovieRepository) if necessary
        {
            _dbContext.Set<Expenditure>().Add(entity);
            await _dbContext.SaveChangesAsync(); // Add, Update and Delete must have this method
            return entity;
        }

        public virtual async Task<Expenditure> DeleteAsync(Expenditure entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<Expenditure> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<Expenditure>().FindAsync(id);
            return entity;
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<Expenditure, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _dbContext.Set<Expenditure>().Where(filter).CountAsync();
            }
            return await _dbContext.Set<Expenditure>().CountAsync();
        }



        public virtual async Task<bool> GetExistingAsync(Expression<Func<Expenditure, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _dbContext.Set<Expenditure>().Where(filter).AnyAsync();
            }
            return false;
        }

        public virtual async Task<IEnumerable<Expenditure>> ListAllAsync()
        {
            return await _dbContext.Set<Expenditure>().ToListAsync();
        }

        public virtual async Task<IEnumerable<Expenditure>> ListAsync(Expression<Func<Expenditure, bool>> filter)
        {
            var filteredList = await _dbContext.Set<Expenditure>().Where(filter).ToListAsync();
            return filteredList;
        }

        public virtual async Task<Expenditure> UpdateAsync(Expenditure entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified; // will look for primary key and update the corresponding record
            await _dbContext.SaveChangesAsync();
            return entity;
        }

    }
}
