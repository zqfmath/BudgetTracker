using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Core.Models.Response
{
    public class IncomeResponseModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public decimal Amount { get; set; }
        public string Desription { get; set; }
        public DateTime? IncomeDate { get; set; }
        public string Remarks { get; set; }
    }
}
