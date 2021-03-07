using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetTracker.Core.Entities
{
    public class Expenditure
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? UserId { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string Description { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime? ExpDate { get; set; }
        [MaxLength(500)]
        [Column(TypeName = "varchar")]
        public string Remarks { get; set; }

        public User User { get; set; }
    }
}
