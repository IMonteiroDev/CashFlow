using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.GetById
{
    public interface IGetExpenseByIdUseCase
    {
        Task<ResponsesExpenseJson> Execute(long id);
    }
}
