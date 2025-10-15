using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repository.Expenses
{
    public interface IExpensesUpdateOnlyRepository
    {
        Task<Expense?> GetById(long id);
        void Update(Expense expense);
    }
}
