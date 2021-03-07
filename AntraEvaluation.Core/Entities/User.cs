using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetTracker.Core.Entities
{
   public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
        [MaxLength(10)]
        [Required]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Fullname { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? JoinedOn { get; set; }

        public ICollection<Income> Incomes { get; set; }
        public ICollection<Expenditure> Expenditures { get; set; }

    }
}
