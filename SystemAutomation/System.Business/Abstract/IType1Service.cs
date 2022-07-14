using System.Collections.Generic;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
    public interface IType1Service
    {
        List<Type1> GetAll();
        void Add(Type1 type1);
        void Update(Type1 type1);
        void Remove(Type1 type1);
    }
}