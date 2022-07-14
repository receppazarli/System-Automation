using System.Collections.Generic;
using System.Windows.Forms;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
    public interface IUserService
    {
        List<User> GetAll();
        void Add(User user);
        void Update(User user);
        void GetUserId(int key, TextBox txt1, TextBox txt2);
    }
}