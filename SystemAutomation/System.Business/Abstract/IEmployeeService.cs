using System.Collections.Generic;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        void Add(Employee employee);
        void Update(Employee employee);
        void Remove(Employee employee);
        
    }
}