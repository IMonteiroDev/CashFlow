using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repository;
using CashFlow.Domain.Repository.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Delete
{
    public class DeleteExpenseUseCase : IDeleteExpenseUseCase
    {
        private readonly IExpensesWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExpenseUseCase(IExpensesWriteOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long id)
        {
            var result = await _repository.Delete(id);

            if (result == false)
            {
                throw new NotFoundException(ResourceErrorMessage.EXPENSE_NOT_FOUND);
            }

            await _unitOfWork.Commit();
        }
    }
}
