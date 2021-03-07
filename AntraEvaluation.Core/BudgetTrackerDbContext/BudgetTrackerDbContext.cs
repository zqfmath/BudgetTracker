using System;
using System.Collections.Generic;
using System.Text;
using BudgetTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;




namespace BudgetTracker.Core
{
   public class BudgetTrackerDbContext : DbContext
    {
        public BudgetTrackerDbContext(DbContextOptions<BudgetTrackerDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //use Fluent API for Movie entity
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Expenditure>();
            modelBuilder.Entity<Income>();

        }

    }
}
