using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.ServiceInterfaces
{
    public interface IIncomeService
    {
        Task<bool> AddIncome(IncomeAddModel income);
        Task<bool> UpdateIncome(IncomeUpdateModel income);
        Task<IncomeResponseModel> GetIncomeById(int id);
        Task<IEnumerable<IncomeResponseModel>> GetIncomeByUserId(int userId);
        Task<IEnumerable<IncomeResponseModel>> GetAllIncomes();
        Task<bool> ExistIncome(int id);
        Task<bool> DeleteIncomeById(int id);
        Task<bool> DeleteIncomeByUserId(int userId);
    }
}
