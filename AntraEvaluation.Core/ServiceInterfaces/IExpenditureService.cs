using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.ServiceInterfaces
{
    public interface IExpenditureService
    {
        Task<bool> AddExpenditure(ExpenditureAddModel expenditure);
        Task<bool> UpdateExpenditure(ExpenditureUpdateModel expenditure);
        Task<ExpenditureResponseModel> GetExpenditureById(int id);
        Task<IEnumerable<ExpenditureResponseModel>> GetExpenditureByUserId(int userId);
        Task<IEnumerable<ExpenditureResponseModel>> GetAllExpenditure();
        Task<bool> ExistExpenditure(int id);
        Task<bool> DeleteExpenditureById(int id);
        Task<bool> DeleteExpenditureByUserId(int userId);

    }
}
