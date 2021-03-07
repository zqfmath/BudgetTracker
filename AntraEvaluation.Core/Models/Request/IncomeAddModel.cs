using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BudgetTracker.Core.Models.Request
{
    public class IncomeAddModel
    {
        public int? UserId { get; set; }
        [Required(ErrorMessage = "Amount cannot be empty")]
        public decimal Amount { get; set; }
        public string Desription { get; set; }
        public DateTime? IncomeDate { get; set; }
        public string Remarks { get; set; }
    }
}
