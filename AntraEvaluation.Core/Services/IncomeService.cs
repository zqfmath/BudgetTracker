using AutoMapper;
using BudgetTracker.Core.Entities;
using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.Models.Response;
using BudgetTracker.Core.RepositoryInterfaces;
using BudgetTracker.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomesRepository _incomeRepository;
        private readonly IMapper _mapper;
        public IncomeService(IIncomesRepository incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddIncome(IncomeAddModel incomeModel)
        {
            var income = _mapper.Map<Income>(incomeModel);
            await _incomeRepository.AddAsync(income);
            return true;
        }

        

        public async Task<IEnumerable<IncomeResponseModel>> GetAllIncomes()
        {
            List<IncomeResponseModel> result = new List<IncomeResponseModel>();
            var incomes = await _incomeRepository.ListAllAsync();
            foreach (var income in incomes)
            {
                result.Add(_mapper.Map<IncomeResponseModel>(income));
            }
            return result;
        }

        public async Task<IncomeResponseModel> GetIncomeById(int id)
        {
            var income = await _incomeRepository.GetByIdAsync(id);
            return _mapper.Map<IncomeResponseModel>(income);
        }

        public async Task<IEnumerable<IncomeResponseModel>> GetIncomeByUserId(int userId)
        {
            var incomes = await _incomeRepository.ListAsync(t=>t.UserId==userId);
            return _mapper.Map<IEnumerable<IncomeResponseModel>>(incomes);
        }

        public async Task<bool> UpdateIncome(IncomeUpdateModel incomeModel)
        {
            var income = _mapper.Map<Income>(incomeModel);
            await _incomeRepository.UpdateAsync(income);
            return true;
        }

        public async Task<bool> ExistIncome(int id)
        {
            return await _incomeRepository.GetExistingAsync(t=>t.Id==id);
        }

        public async Task<bool> DeleteIncomeById(int id)
        {
            var income = await _incomeRepository.GetByIdAsync(id);
            await _incomeRepository.DeleteAsync(income);
            return true;
        }

        public async Task<bool> DeleteIncomeByUserId(int userId)
        {
            var incomes = await _incomeRepository.ListAsync(t => t.UserId == userId);
            foreach (var income in incomes)
            {
                await _incomeRepository.DeleteAsync(income);
            }
            return true;
        }
    }
}
