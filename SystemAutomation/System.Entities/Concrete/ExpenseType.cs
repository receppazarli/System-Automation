using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.Entities.Abstract;

namespace IlimYayma.Entities.Concrete
{
    public class ExpenseType : IEntity
    {
        public int Id { get; set; }
        public string ExpenseTypeName { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int LastUpUser { get; set; }
        public DateTime LastUpDate { get; set; }
        public bool DeleteFlag { get; set; }


    }
}
