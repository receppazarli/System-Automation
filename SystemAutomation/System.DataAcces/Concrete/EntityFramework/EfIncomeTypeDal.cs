using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.DataAcces.Abstract;
using IlimYayma.DataAcces.Concrete.EntityFramework;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.DataAcces.Concrete
{
    public class EfIncomeTypeDal:EfEntityRepositoryBase<IncomeType,SystemContext>,IIncomeTypeDal
    {

    }
}
