using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.Entities.Abstract;

namespace IlimYayma.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string klnc_ad { get; set; }
        public string klnc_sifre { get; set; }
        public string klnc_yetki { get; set; }
        public bool DeleteFlag { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int LastUpUser { get; set; }
        public DateTime LastUpDate { get; set; }

    }
}
