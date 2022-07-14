using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.Entities.Concrete;
using Type = IlimYayma.Entities.Concrete.Type1;

namespace IlimYayma.DataAcces.Concrete.EntityFramework
{
   public class IlimYaymaContext :DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeType> IncomeTypes { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Type1> Type1 { get; set; }
        public DbSet<User> Users  { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<UserAuthorization> UserAuthorizations { get; set; }
    }
}
