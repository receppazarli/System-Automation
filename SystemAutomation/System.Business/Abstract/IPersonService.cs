using System.Collections.Generic;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
    public interface IPersonService
    {
        List<Person> GetAll();
        void Add(Person person);
        void Update(Person person);
        void Remove(Person person);
    }
}