using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Abstract
{
    public interface IUserAuthorizationService
    {
        List<UserAuthorization> GetAll();
    }
}
