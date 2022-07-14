using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.DataAcces.Abstract;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
    public class DistrictManager: IDistrictService
    {
        private IDistrictDal _districtDal;

        public DistrictManager(IDistrictDal districtDal)
        {
            _districtDal = districtDal;
        }

        public List<District> GetAll(int key)
        {
            return _districtDal.GetAll(x => x.CityId == key).ToList();
        }
    }
}
