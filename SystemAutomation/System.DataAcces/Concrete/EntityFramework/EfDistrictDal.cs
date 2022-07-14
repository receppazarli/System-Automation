using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.DataAcces.Abstract;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.DataAcces.Concrete.EntityFramework
{
    public class EfDistrictDal :EfEntityRepositoryBase<District,SystemContext>,IDistrictDal
    {
    }
}
