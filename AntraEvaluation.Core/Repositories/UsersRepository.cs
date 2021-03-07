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
    public class UsersRepository : IUsersRepository
    {
        protected readonly BudgetTrackerDbContext _dbContext; // protected: current class and its subclasses
        public UsersRepository(BudgetTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<User> AddAsync(User entity) // make all the methods virtural: we can override those methods in other repositories(e.g.: MovieRepository) if necessary
        {
            _dbContext.Set<User>().Add(entity);
            await _dbContext.SaveChangesAsync(); // Add, Update and Delete must have this method
            return entity;
        }

        public virtual async Task<User> DeleteAsync(User entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<User> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<User>().FindAsync(id);
            return entity;
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<User, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _dbContext.Set<User>().Where(filter).CountAsync();
            }
            return await _dbContext.Set<User>().CountAsync();
        }



        public virtual async Task<bool> GetExistingAsync(Expression<Func<User, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _dbContext.Set<User>().Where(filter).AnyAsync();
            }
            return false;
        }

        public virtual async Task<IEnumerable<User>> ListAllAsync()
        {
            return await _dbContext.Set<User>().ToListAsync();
        }

        public virtual async Task<IEnumerable<User>> ListAsync(Expression<Func<User, bool>> filter)
        {
            var filteredList = await _dbContext.Set<User>().Where(filter).ToListAsync();
            return filteredList;
        }

        public virtual async Task<User> UpdateAsync(User entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified; // will look for primary key and update the corresponding record
            await _dbContext.SaveChangesAsync();
            return entity;
        }

    }
}
