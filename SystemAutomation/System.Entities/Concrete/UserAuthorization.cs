using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.Entities.Abstract;

namespace IlimYayma.Entities.Concrete
{
    public class UserAuthorization : IEntity
    {

        public int Id { get; set; }
        public string AuthorizationId { get; set; }
        public string UserAuthorizationName { get; set; }
    }
}
