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
    public class ExpenditureService : IExpenditureService
    {
        private readonly IExpendituresRespository _expenditureRepository;
        private readonly IMapper _mapper;
        public ExpenditureService(IExpendituresRespository expenditureRepository, IMapper mapper)
        {
            _expenditureRepository = expenditureRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddExpenditure(ExpenditureAddModel expenditureModel)
        {
            var expenditure = _mapper.Map<Expenditure>(expenditureModel);
            await _expenditureRepository.AddAsync(expenditure);
            return true;
        }

        public async Task<IEnumerable<ExpenditureResponseModel>> GetAllExpenditure()
        {
            List<ExpenditureResponseModel> result = new List<ExpenditureResponseModel>();
            var expenditures = await _expenditureRepository.ListAllAsync();
            foreach (var expenditure in expenditures)
            {
                result.Add(_mapper.Map<ExpenditureResponseModel>(expenditure));
            }
            return result;
        }

        public async Task<ExpenditureResponseModel> GetExpenditureById(int id)
        {
            var expenditure = await _expenditureRepository.GetByIdAsync(id);
            return _mapper.Map<ExpenditureResponseModel>(expenditure);
        }

        public async Task<IEnumerable<ExpenditureResponseModel>> GetExpenditureByUserId(int userId)
        {
            var expenditures = await _expenditureRepository.ListAsync(t => t.UserId == userId);
            return _mapper.Map<IEnumerable<ExpenditureResponseModel>>(expenditures);
        }

        public async Task<bool> UpdateExpenditure(ExpenditureUpdateModel expenditureModel)
        {
            var expenditure = _mapper.Map<Expenditure>(expenditureModel);
            await _expenditureRepository.UpdateAsync(expenditure);
            return true;
        }

        public async Task<bool> ExistExpenditure(int id)
        {
            return await _expenditureRepository.GetExistingAsync(t => t.Id == id);
        }

        public async Task<bool> DeleteExpenditureById(int id)
        {
            var expenditure = await _expenditureRepository.GetByIdAsync(id);
            await _expenditureRepository.DeleteAsync(expenditure);
             return true;
        }

        public async Task<bool> DeleteExpenditureByUserId(int userId)
        {
            var expenditures = await _expenditureRepository.ListAsync(t => t.UserId == userId);
            foreach (var expenditure in expenditures)
            {
                await _expenditureRepository.DeleteAsync(expenditure);
            }
            return true;
        }
    }
}
