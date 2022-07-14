using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.Entities.Abstract;

namespace IlimYayma.Entities.Concrete
{
    public class Type1 : IEntity
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Unit { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int LastUpUser { get; set; }
        public DateTime LastUpDate { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
