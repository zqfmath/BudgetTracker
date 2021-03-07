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
    public class IncomesRepository : IIncomesRepository
    {
        protected readonly BudgetTrackerDbContext _dbContext; // protected: current class and its subclasses
        public IncomesRepository(BudgetTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<Income> AddAsync(Income entity) // make all the methods virtural: we can override those methods in other repositories(e.g.: MovieRepository) if necessary
        {
            _dbContext.Set<Income>().Add(entity);
            await _dbContext.SaveChangesAsync(); // Add, Update and Delete must have this method
            return entity;
        }

        public virtual async Task<Income> DeleteAsync(Income entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<Income> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<Income>().FindAsync(id);
            return entity;
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<Income, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _dbContext.Set<Income>().Where(filter).CountAsync();
            }
            return await _dbContext.Set<Income>().CountAsync();
        }



        public virtual async Task<bool> GetExistingAsync(Expression<Func<Income, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _dbContext.Set<Income>().Where(filter).AnyAsync();
            }
            return false;
        }

        public virtual async Task<IEnumerable<Income>> ListAllAsync()
        {
            return await _dbContext.Set<Income>().ToListAsync();
        }

        public virtual async Task<IEnumerable<Income>> ListAsync(Expression<Func<Income, bool>> filter)
        {
            var filteredList = await _dbContext.Set<Income>().Where(filter).ToListAsync();
            return filteredList;
        }

        public virtual async Task<Income> UpdateAsync(Income entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified; // will look for primary key and update the corresponding record
            await _dbContext.SaveChangesAsync();
            return entity;
        }

    }
}
