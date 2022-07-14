using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
    public interface IExpenseService
    {
        void Add(Expense expense);
        void Update(Expense expense);
    }
}