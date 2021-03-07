using AutoMapper;
using BudgetTracker.Core.Entities;
using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Core.Helpers
{
   public class BudgetTrackerMappingProfile: Profile
    {
        public BudgetTrackerMappingProfile()
        {
            CreateMap<User, UserResponseModel>();
            CreateMap<UserAddModel, User>();
            CreateMap<UserUpdateModel, User>();

            CreateMap<Income, IncomeResponseModel>();
            CreateMap<IncomeAddModel, Income>();
            CreateMap<IncomeUpdateModel, Income>();

            CreateMap<Expenditure, ExpenditureResponseModel>();
            CreateMap<ExpenditureAddModel, Expenditure>();
            CreateMap<ExpenditureUpdateModel, Expenditure>();
        }
        
    }
}
