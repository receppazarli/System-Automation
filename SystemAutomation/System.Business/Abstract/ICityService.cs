using System.Collections.Generic;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
    public interface ICityService
    {
        List<City> GetAll();
    }
}