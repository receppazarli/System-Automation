using System.Collections.Generic;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
    public interface IDistrictService
    {
        List<District> GetAll(int key);
    }
}