using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.DataAcces.Abstract;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.DataAcces.Concrete.EntityFramework
{
    public class EfPersonDal:EfEntityRepositoryBase<Person,SystemContext>,IPersonDal
    {

    }
}
