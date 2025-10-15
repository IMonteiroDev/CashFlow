using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repository.Expenses
{
    public interface IExpensesWriteOnlyRepository
    {
        Task Add(Expense expense);

        /// <summary>
        /// This function returns TRUE if the deletion was successfull otherwise return FALSE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Task<bool> Delete(long id);
    }
}
