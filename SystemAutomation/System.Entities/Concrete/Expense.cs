using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.Entities.Abstract;

namespace IlimYayma.Entities.Concrete
{
    public class Expense : IEntity
    {
        public Expense()
        {
            Quantity = 0.0;
        }
        public int Id { get; set; }
        public int ExpenseTypeId { get; set; }
        public int WhomPerson { get; set; }
        public int WhoEmployee { get; set; }
        public int TypeId { get; set; }
        public double Quantity { get; set; }
        public DateTime ExpenseIssueDate { get; set; }
        public string Explanation { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int LastUpUser { get; set; }
        public DateTime LastUpDate { get; set; }
        public bool DeleteFlag { get; set; }



    }
}
