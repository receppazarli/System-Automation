using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.DataAcces.Abstract;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
   public class CityManager :ICityService
   {
       private ICityDal _cityDal;

       public CityManager(ICityDal cityDal)
       {
           _cityDal = cityDal;
       }


       public List<City> GetAll()
       {
           return _cityDal.GetAll();
       }
    }
}
